namespace Talks.Domain
{
    public class Talk
    {
        /// <summary>
        /// Talk Id
        /// </summary>
        public int TalkId { get; set; }
        /// <summary>
        /// Talk Reference Id
        /// </summary>
        public Guid TalkReferenceId { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }= string.Empty;
        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract { get; set; } = string.Empty;
        /// <summary>
        /// Object of the type <see cref="Domain.Level"/>
        /// </summary>
        public Level Level { get; set; }
        /// <summary>
        /// IEnumerable of object of the type <see cref="Training"/>
        /// </summary>
        public IEnumerable<Training> Trainings { get; set; } = Enumerable.Empty<Training>();
    }
}
