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

                var trainings = talk.Trainings;

                return _mapper.Map<IEnumerable<TrainingDTO>>(trainings);
            }
            catch (Exception e)
            {
                _logger.LogError($"Getting all Trainings, Error Message: {0}", e.Message);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public async Task<TrainingDTO> GetTrainingAsync(Guid talkReferenceId, string code)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                _logger.LogInformation($"Getting training with task id: {0} and code: {1}", talkReferenceId, code);

                var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

                return _mapper.Map<TrainingDTO>(training);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Getting training with task id: {0} and code: {1}, Error Message: {2}", talkReferenceId, code, e.Message);
                throw;
            }
            
        }
    }
}
