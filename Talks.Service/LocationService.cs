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
        public async Task<LocationDTO> GetLocationAsync(Guid talkReferenceId, string code)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

                _logger.LogInformation($"Getting Location information for task id: {0} and training: {1}", talkReferenceId, code);

                var location = training?.Location;

                return _mapper.Map<LocationDTO>(location);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Getting Location information for task id: {0} and training: {1}, Error Message: {2}", talkReferenceId, code, e.Message);
                throw;
            }
        }
    }
}
