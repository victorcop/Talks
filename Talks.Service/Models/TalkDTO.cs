namespace Talks.Service.Models
{
    public class TalkDTO
    {
        public int TalkId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public IEnumerable<TrainingDTO> Trainings { get; set; } = new List<TrainingDTO>();
    }
}
