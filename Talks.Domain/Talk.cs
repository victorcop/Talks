using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Talks.Domain
{
    [ExcludeFromCodeCoverage]
    public class Talk
    {
        /// <summary>
        /// Talk Reference Id
        /// </summary>
        [Key]
        public Guid TalkId { get; set; }
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
