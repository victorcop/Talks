namespace Talks.Service.Models
{
    public class TalksDTO
    {
        public int TalkId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
    }
}
