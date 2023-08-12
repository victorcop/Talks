using Talks.Domain;

namespace Talks.Data.Repositories
{
    internal class TalkRepository : ITalkRepository
    {
        public List<Talk> GetTalksAsync()
        {
            var talks = new List<Talk>
            {
                new Talk { TalkId = 1, SpeakerId = 1, Title = "Teach Talk", Abstract =  "Best Web development frameworks on 2023", Level = 1},
                new Talk { TalkId = 1, SpeakerId = 1, Title = "Anime Talk", Abstract =  "Best Shonnen Jump Animes on 2023", Level = 1},
            };

            return talks;
        }
    }
}
