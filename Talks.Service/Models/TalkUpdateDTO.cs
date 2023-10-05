using System.ComponentModel.DataAnnotations;
using Talks.Domain;

namespace Talks.Service.Models
{
    public class TalkUpdateDTO
    {
        /// <summary>
        /// Talk Reference Id
        /// </summary>
        [Required]
        public Guid TalkReferenceId { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// Abstract
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Abstract { get; set; }
        /// <summary>
        /// Object of the type <see cref="Level"/>
        /// </summary>
        [Range(1, 4)]
        public Level Level { get; set; }
        /// <summary>
        /// IEnumerable of object of the type <see cref="Location"/>
        /// </summary>
        public IEnumerable<Training> Trainings { get; set; }
    }
}
