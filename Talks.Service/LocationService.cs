using AutoMapper;
using Microsoft.Extensions.Logging;
using Talks.Data.Repositories;
using Talks.Service.Models;

namespace Talks.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public LocationService(ITalkRepository talkRepository, IMapper mapper, ILogger<LocationService> logger)
        {
            _logger = logger;
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<LocationDTO> GetLocationAsync(int talkId, string code)
        {
            var talk = await _talkRepository.GetTalkAsync(talkId);

            var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

            _logger.LogInformation($"Getting Location information for task id: {talkId} and training: {code}", talkId, code);

            var location = training?.Location;

            return _mapper.Map<LocationDTO>(location);
        }
    }
}
