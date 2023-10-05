namespace Talks.Domain
{
    public class Speaker
    {
        /// <summary>
        /// Speaker Id
        /// </summary>
        public int SpeakerId { get; set; }
        /// <summary>
        /// Speaker Reference Id
        /// </summary>
        public Guid SpeakerReferenceId { get; set; }
        /// <summary>
        /// Speaker First Name
        /// </summary>
        public string? FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Last Name
        /// </summary>
        public string? LastName { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Middle Name
        /// </summary>
        public string? MiddleName { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Company
        /// </summary>
        public string? Company { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Company Url
        /// </summary>
        public string? CompanyUrl { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Blog Url
        /// </summary>
        public string? BlogUrl { get; set; } = string.Empty;
        /// <summary>
        /// Speaker Twitter
        /// </summary>
        public string? Twitter { get; set; } = string.Empty;
        /// <summary>
        /// Speaker GitHub
        /// </summary>
        public string? GitHub { get; set; } = string.Empty;
    }
}
