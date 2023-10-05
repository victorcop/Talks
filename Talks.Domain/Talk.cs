﻿namespace Talks.Domain
{
    public class Talk
    {
        /// <summary>
        /// Talk Id
        /// </summary>
        public int TalkId { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract { get; set; }
        /// <summary>
        /// Object of the type <see cref="Level"/>
        /// </summary>
        public Level Level { get; set; }
        /// <summary>
        /// IEnumerable of object of the type <see cref="Location"/>
        /// </summary>
        public IEnumerable<Training> Trainings { get; set; }
    }
}
