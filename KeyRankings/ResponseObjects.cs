namespace KeySpecificRankings {
    class Score {
        public int beatmap_id;
        public int score;
        public int maxcombo;
        public int count50;
        public int count100;
        public int count300;
        public int countmiss;
        public int countkatu;
        public int countgeki;
        public byte perfect;
        public int enabled_mods;
        public int user_id;
        public string date;
        public string rank;
        public float pp;
    }

    class Beatmap {
        public int approved;
        public string approved_date;
        public string last_update;
        public string artist;
        public int beatmap_id;
        public int beatmapset_id;
        public float bpm;
        public string creator;
        public float difficultyrating;
        public float diff_size;
        public float diff_overall;
        public float diff_approach;
        public float diff_drain;
        public int hit_length;
        public string source;
        public int genre_id;
        public int language_id;
        public string title;
        public int total_length;
        public string version;
        public string file_md5;
        public byte mode;
        public string tags;
        public int favourite_count;
        public int playcount;
        public int passcount;
        public int maxcombo;

    }
}
