using Microsoft.Extensions.Logging;
using Talks.Domain;

namespace Talks.Data.Repositories
{
    internal class InMemoryTalkRepository : ITalkRepository
    {
        private readonly List<Talk> _talks;
        private readonly ILogger<InMemoryTalkRepository> _logger;

        public InMemoryTalkRepository(ILogger<InMemoryTalkRepository> logger)
        {
            _logger = logger;
            _talks = new List<Talk>
            {
                new Talk { 
                    TalkId = 1, 
                    Title = "Teach Talk", 
                    Abstract =  "Best Web development frameworks on 2023", 
                    Level = Level.Middle,
                    Trainings = new List<Training>
                    {
                        new Training
                        {
                            Code = "NETCONF",
                            EventDate = DateTime.Now,
                            TrainingId = 1,
                            Length = 50,
                            Name = "Dotnet 6 Conference",
                            Speaker = new Speaker
                            {
                                SpeakerId = 1,
                                FirstName = "Victor",
                                LastName = "Velasquez",
                                MiddleName = "Emilio",
                                CompanyUrl = "Delta.net",
                                Twitter = "@victorcop55",
                                GitHub = "https://github.com/victorcop",
                                Company = "Delta",
                                BlogUrl = ""
                            },
                            Location = new Location
                            {
                                Address1 = ".NET virtual event",
                                CityTown = "Global",
                                Country = "Earth",
                                LocationId = 1,
                            }
                        }
                    }
                },
                new Talk {
                    TalkId = 2,
                    Title = "Anime Talk",
                    Abstract =  "Best Shonnen Jump Animes on 2023",
                    Level = Level.Advance,
                    Trainings = new List<Training>
                    {
                        new Training
                        {
                            Code = "OTAKUCONF",
                            EventDate = DateTime.Now,
                            TrainingId = 2,
                            Length = 50,
                            Name = "Best Shonnen Jump Animes on 2023",
                            Speaker = new Speaker
                            {
                                SpeakerId = 1,
                                FirstName = "Victor",
                                LastName = "Velasquez",
                                MiddleName = "Emilio",
                                CompanyUrl = "Delta.net",
                                Twitter = "@victorcop55",
                                GitHub = "https://github.com/victorcop",
                                Company = "Delta",
                                BlogUrl = ""
                            },
                            Location = new Location
                            {
                                Address1 = ".NET virtual event",
                                CityTown = "Global",
                                Country = "Earth",
                                LocationId = 1,
                            }
                        }
                    }
                }
            };
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Talk>> GetTalksAsync()
        {
            _logger.LogInformation($"Getting all Talks");
            return await Task.FromResult(_talks);
        }

        /// <inheritdoc/>
        public async Task<Talk> GetTalkAsync(int talkId)
        {
            _logger.LogInformation($"Getting talk with task id: {talkId}", talkId);
            return await Task.FromResult(_talks.FirstOrDefault(t => t.TalkId == talkId));
        }

        /// <inheritdoc/>
        public async Task<Talk> AddTalkAsync(Talk talk)
        {
            _logger.LogInformation($"Adding Talk");

            _talks.Add(talk);

            return await Task.FromResult(_talks.FirstOrDefault(t => t.TalkId == talk.TalkId));
        }

        /// <inheritdoc/>
        public int GetLastTalkId()
        {
            return _talks.Max(t => t.TalkId);
        }
    }
}
