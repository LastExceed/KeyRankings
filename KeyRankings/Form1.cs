﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace KeyRankings {
    public partial class Form1 : Form {
        const string website = "http://osu.ppy.sh/";
        List<Result> results;
        int previousOrder = -1;
        Thread thatThread;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            textBoxCountryTag.Enabled = false;
            progressBarTotal.Value = progressBarTotal.Minimum;
            progressBarUser.Value = progressBarUser.Minimum;
            listView1.Items.Clear();
            thatThread = new Thread(Run);
            thatThread.Start();
        }

        public string GetHttp(string url) {
            while (true) {
                try {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 1000;
                    request.AutomaticDecompression = DecompressionMethods.GZip;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream)) {
                        return reader.ReadToEnd();
                    }
                } catch (IOException) {//sometimes the stream just closes before we can read the reasponse
                } catch (WebException ex) {//when the key is invalid
                    if (ex.Status != WebExceptionStatus.Timeout) {
                        Invoke(new Action(() => Finish()));
                        MessageBox.Show("invalid API key");
                        thatThread.Abort();
                        throw;
                    }
                }
            }
        }

        public void Run() {
            Invoke(new Action(() => progressBarTotal.Style = ProgressBarStyle.Marquee));
            Invoke(new Action(() => progressBarUser.Style = ProgressBarStyle.Marquee));

            Dictionary<int, float> maps;
            if (File.Exists("maps.json")) {
                try {
                    maps = JsonConvert.DeserializeObject<Dictionary<int, float>>(File.ReadAllText("maps.json"));
                } catch (Exception) {
                    MessageBox.Show("error reading file 'maps.json', rebuilding from scratch");
                    maps = new Dictionary<int, float>();
                }
            } else {
                maps = new Dictionary<int, float>();
            }
            string APIkey = textBoxKey.Text;
            var url = string.Format("{0}p/pp/?m=3&c={1}", website, textBoxCountryTag.Text);

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = htmlWeb.Load(url);
            List<HtmlNode> users = htmlDocument.DocumentNode.SelectNodes("//tr").ToList();
            Invoke(new Action(() => progressBarTotal.Maximum = users.Count));
            users.RemoveAt(0); //this isn't a user

            Invoke(new Action(() => progressBarTotal.Style = ProgressBarStyle.Continuous));
            Invoke(new Action(() => progressBarUser.Style = ProgressBarStyle.Continuous));



            results = new List<Result>();
            foreach (HtmlNode user in users) {
                Invoke(new Action(() => progressBarUser.Value = progressBarUser.Minimum));
                Result result = new Result();
                result.name = user.ChildNodes[3].LastChild.InnerText;
                ListViewItem listViewItem = new ListViewItem(result.name);
                for (int i = 0; i < 6; i++) {
                    listViewItem.SubItems.Add("0");
                }
                Invoke(new Action(() => listView1.Items.Add(listViewItem)));

                url = string.Format("{0}api/get_user_best?k={1}&u={2}&m=3&limit=1000", website, APIkey, result.name);
                Score[] scores = JsonConvert.DeserializeObject<Score[]>(GetHttp(url));
                Invoke(new Action(() => progressBarUser.Maximum = scores.Length + 1));
                foreach (Score score in scores) {
                    int beatmap_id = score.beatmap_id;
                    float keymode;
                    if (maps.ContainsKey(beatmap_id)) {
                        keymode = maps[beatmap_id];
                    } else {
                        url = string.Format("{0}api/get_beatmaps?k={1}&b={2}", website, APIkey, beatmap_id);
                        Beatmap[] beatmaps = JsonConvert.DeserializeObject<Beatmap[]>(GetHttp(url));
                        keymode = beatmaps[0].diff_size;
                        
                        maps.Add(beatmap_id, keymode);
                        File.WriteAllText("maps.json", JsonConvert.SerializeObject(maps));
                    }
                    if (keymode < 4) {
                        keymode = 3; //autoconverts, keymod is TODO
                    }
                    result.pp[(int)keymode] += score.pp * Math.Pow(0.95, result.count[(int)keymode]);
                    Invoke(new Action(() => listViewItem.SubItems[(int)keymode-3].Text = "" + result.pp[(int)keymode]));
                    result.count[(int)keymode]++;
                    Invoke(new Action(() => StepInstant(progressBarUser)));
                }
                int rankedPlays = int.Parse(user.ChildNodes[11].InnerText.Replace(",", ""));
                rankedPlays += int.Parse(user.ChildNodes[13].InnerText.Replace(",", ""));
                rankedPlays += int.Parse(user.ChildNodes[15].InnerText.Replace(",", ""));
                int totalcount = 0;
                for (int i = 4; i < 10; i++) {
                    totalcount += result.count[i];
                }
                for (int i = 4; i < 10; i++) {
                    result.pp[i] += 416.666666667 * (1 - Math.Pow(0.9994, rankedPlays * (result.count[i] / totalcount)));
                    Invoke(new Action(() => listViewItem.SubItems[i-3].Text = "" + result.pp[i]));
                }
                results.Add(result);
                Invoke(new Action(() => StepInstant(progressBarTotal)));
            }
            Invoke(new Action(() => Finish()));
        }
        public void Finish() {
            progressBarTotal.Value = progressBarTotal.Maximum;
            progressBarUser.Value = progressBarUser.Maximum;
            textBoxCountryTag.Enabled = true;
            button1.Enabled = true;
        }

        public void StepInstant(ProgressBar progressBar) {
            progressBar.Value += 2;
            progressBar.Value -= 1;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == 0) {
                if (previousOrder == e.Column) {
                    results = results.OrderByDescending(x => x.name).ToList();
                    previousOrder = -1;
                } else {
                    results = results.OrderBy(x => x.name).ToList();
                    previousOrder = e.Column;
                }
            } else {
                results = results.OrderBy(x => x.pp[e.Column]).ToList();
            }
            Invoke(new Action(() => listView1.Items.Clear()));
            foreach (var item in results) {
                ListViewItem listViewItem = new ListViewItem(item.name);
                foreach (var result in results) {
                    foreach (var pp in result.pp) {
                        listViewItem.SubItems.Add("" + pp);
                    }
                }
                Invoke(new Action(() => listView1.Items.Add(listViewItem)));
            }
        }

        private void textBoxKey_Enter(object sender, EventArgs e) {
            textBoxKey.Text = string.Empty;
            textBoxKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
            textBoxKey.PasswordChar = Char.Parse("•");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://github.com/LastExceed/KeyRankings");
            linkLabel1.LinkVisited = true;
        }
    }
}
