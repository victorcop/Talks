using System.ComponentModel.DataAnnotations;
using Talks.Domain;

namespace Talks.Service.Models
{
    public class TalkCreationDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Abstract { get; set; } = string.Empty;
        [Range(1,4)]
        public Level Level { get; set; }
    }
}
