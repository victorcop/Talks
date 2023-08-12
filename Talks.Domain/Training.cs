namespace Talks.Domain
{
    public class Training
    {
        /// <summary>
        /// Training Id
        /// </summary>
        public int TrainingId { get; set; }
        public Speaker Speaker { get; set; }
        /// <summary>
        /// Training name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Training code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Training location object of the type <see cref="Location"/>
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// Event Date
        /// </summary>
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Training Length
        /// </summary>
        public int Length { get; set; } = 1;
    }
}