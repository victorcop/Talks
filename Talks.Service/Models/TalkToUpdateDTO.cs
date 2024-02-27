using System.ComponentModel.DataAnnotations;
using Talks.Domain;

namespace Talks.Service.Models
{
    public class TalkToUpdateDTO
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Abstract
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Abstract { get; set; } = string.Empty;
        /// <summary>
        /// Object of the type <see cref="Level"/>
        /// </summary>
        [Range(1, 4)]
        public Level Level { get; set; }
    }
}
