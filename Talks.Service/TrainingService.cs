using AutoMapper;
using Microsoft.Extensions.Logging;
using Talks.Data.Repositories;
using Talks.Service.Models;

namespace Talks.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ILogger<TrainingService> _logger;
        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public TrainingService(ITalkRepository talkRepository, IMapper mapper, ILogger<TrainingService> logger)
        {
            _logger = logger;
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TrainingDTO>> GetAllTrainingsAsync(Guid talkReferenceId)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                _logger.LogInformation($"Getting all Trainings");

                if (talk == null) { return Enumerable.Empty<TrainingDTO>(); }

                var trainings = talk.Trainings;

                return _mapper.Map<IEnumerable<TrainingDTO>>(trainings);
            }
            catch (Exception e)
            {
                _logger.LogError($"Getting all Trainings, Error Message: {e.Message}");
                throw;
            }
            
        }

        /// <inheritdoc/>
        public async Task<TrainingDTO?> GetTrainingAsync(Guid talkReferenceId, Guid trainingReferenceId)
        {
            try
            {
                _logger.LogInformation($"Getting training with talk id: {talkReferenceId} and Training Reference Id: {trainingReferenceId}");

                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);
                
                if (talk == null) { return null; }

                var training = talk.Trainings.FirstOrDefault(t => t.TrainingId == trainingReferenceId);

                return _mapper.Map<TrainingDTO>(training);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Getting training with talk id: {talkReferenceId} and Training Reference Id: {trainingReferenceId}, Error Message: {e.Message}");
                throw;
            }
            
        }
    }
}
