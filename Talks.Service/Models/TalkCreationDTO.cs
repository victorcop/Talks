using Talks.Domain;

namespace Talks.Service.Models
{
    public class TalkCreationDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public Level Level { get; set; }
    }
}
