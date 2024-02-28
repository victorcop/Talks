using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
                    TalkId = Guid.NewGuid(),
                    Title = "Teach Talk", 
                    Abstract =  "Best Web development frameworks on 2023", 
                    Level = Level.Middle,
                    Trainings = new List<Training>
                    {
                        new Training
                        {
                            TrainingId = Guid.NewGuid(),
                            Code = "NETCONF",
                            EventDate = DateTime.Now,
                            Length = 50,
                            Name = "Dotnet 6 Conference",
                            Speaker = new Speaker
                            {
                                SpeakerId = Guid.NewGuid(),
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
                                LocationId = Guid.NewGuid()
                            }
                        }
                    }
                },
                new Talk {
                    TalkId = Guid.NewGuid(),
                    Title = "Anime Talk",
                    Abstract =  "Best Shonnen Jump Animes on 2023",
                    Level = Level.Advance,
                    Trainings = new List<Training>
                    {
                        new Training
                        {
                            TrainingId = Guid.NewGuid(),
                            Code = "OTAKUCONF",
                            EventDate = DateTime.Now,
                            Length = 50,
                            Name = "Best Shonnen Jump Animes on 2023",
                            Speaker = new Speaker
                            {
                                SpeakerId= Guid.NewGuid(),
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
                                LocationId = Guid.NewGuid()
                            }
                        }
                    }
                }
            };
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Talk?>> GetTalksAsync()
        {
            _logger.LogInformation($"Getting all Talks");
            return await Task.FromResult(_talks);
        }

        /// <inheritdoc/>
        public async Task<Talk?> GetTalkAsync(Guid talkReferenceId)
        {
            _logger.LogInformation($"Getting talk with talk id: {talkReferenceId}");
            return await Task.FromResult(_talks.FirstOrDefault(t => t.TalkId == talkReferenceId));
        }

        /// <inheritdoc/>
        public async Task<Talk?> AddTalkAsync(Talk talk)
        {
            _logger.LogInformation($"Adding Talk");

            _talks.Add(talk);

            return await Task.FromResult(_talks.FirstOrDefault(t => t.TalkId == talk.TalkId));
        }

        /// <inheritdoc/>
        public async Task<Talk?> UpdateTalkAsync(Talk talk)
        {
            _logger.LogInformation($"Updating Talk");

            var talkToUpdate = _talks.Where(t => t.TalkId == talk.TalkId).FirstOrDefault();

            if (talkToUpdate == null) { return null; }

            talkToUpdate.Title = talk.Title;
            talkToUpdate.Abstract = talk.Abstract;
            talkToUpdate.Level = talk.Level;

            return await Task.FromResult(talkToUpdate);
        }

        /// <inheritdoc/>
        public Guid GetLastTalkId()
        {
            return _talks.Max(t => t.TalkId);
        }

        /// <inheritdoc/>
        public Task DeleteTalkAsync(Guid talkReferenceId)
        {
            _logger.LogInformation($"Deleting Talk with reference Id: {talkReferenceId}");

            var talkToUpdate = _talks.FirstOrDefault(t => t.TalkId == talkReferenceId);

            if (talkToUpdate != null)
            {
                _talks.Remove(talkToUpdate);
            }

            return Task.CompletedTask;
        }
    }
}
