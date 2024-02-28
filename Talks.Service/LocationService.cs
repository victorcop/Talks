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
        public async Task<LocationDTO?> GetLocationAsync(Guid talkReferenceId, Guid trainingReferenceId)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                if (talk == null) { return null; }

                var training = talk.Trainings.FirstOrDefault(t => t.TrainingId == trainingReferenceId);

                _logger.LogInformation($"Getting Location information for talk id: {talkReferenceId} and training: {trainingReferenceId}");

                var location = training?.Location;

                return _mapper.Map<LocationDTO>(location);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Getting Location information for talk id: {talkReferenceId} and training: {trainingReferenceId}, Error Message: {e.Message}");
                throw;
            }
        }
    }
}
