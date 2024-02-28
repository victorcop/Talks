using Talks.Domain;

namespace Talks.Service.Models
{
    public class TalkDTO
    {
        public Guid TalkId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public Level Level { get; set; }
        public IEnumerable<TrainingDTO> Trainings { get; set; } = new List<TrainingDTO>();
    }
}
