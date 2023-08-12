﻿namespace Talks.Service.Models
{
    public class TrainingDTO
    {
        /// <summary>
        /// Training name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Training code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Training date
        /// </summary>
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Training Length
        /// </summary>
        public int Length { get; set; } = 1;
        /// <summary>
        /// Training location object of the type <see cref="LocationDTO"/>
        /// </summary>
        public LocationDTO Location { get; set; }
        /// <summary>
        /// Training location object of the type <see cref="SpeakerDTO"/>
        /// </summary>
        public SpeakerDTO Speaker { get; set; }
    }
}