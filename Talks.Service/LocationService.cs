using AutoMapper;
using Talks.Data.Repositories;
using Talks.Service.Models;

namespace Talks.Service
{
    public class LocationService : ILocationService
    {
        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public LocationService(ITalkRepository talkRepository, IMapper mapper)
        {
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public LocationDTO GetLocationAsync(int talkId, string code)
        {
            var talk = _talkRepository.GetTalkAsync(talkId);

            var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

            var location = training?.Location;

            return _mapper.Map<LocationDTO>(location);
        }
    }
}
