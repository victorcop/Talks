﻿namespace Talks.Domain
{
    public class Talk
    {
        public int TalkId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public int SpeakerId { get; set; }
    }
}
