using Talks.Domain;

namespace Talks.Data.Repositories
{
    internal class TalkRepository : ITalkRepository
    {
        private readonly IEnumerable<Talk> _talks;

        public TalkRepository()
        {
            _talks = new List<Talk>
            {
                new Talk { 
                    TalkId = 1, 
                    Title = "Teach Talk", 
                    Abstract =  "Best Web development frameworks on 2023", 
                    Level = 1,
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
                    Level = 1,
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
        public IEnumerable<Talk> GetTalksAsync()
        {
            return _talks;
        }

        /// <inheritdoc/>
        public Talk GetTalkAsync(int talkId)
        {
            return _talks.FirstOrDefault(t => t.TalkId == talkId);
        }
    }
}
