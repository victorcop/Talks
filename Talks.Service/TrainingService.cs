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
        public async Task<IEnumerable<TrainingDTO>> GetAllTrainingsAsync(int talkId)
        {
            var talk = await _talkRepository.GetTalkAsync(talkId);

            _logger.LogInformation($"Getting all Trainings");

            var trainings = talk.Trainings;

            return _mapper.Map<IEnumerable<TrainingDTO>>(trainings);
        }

        /// <inheritdoc/>
        public async Task<TrainingDTO> GetTrainingAsync(int talkId, string code)
        {
            var talk = await _talkRepository.GetTalkAsync(talkId);

            _logger.LogInformation($"Getting training with task id: {talkId} and code: {code}", talkId, code);

            var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

            return _mapper.Map<TrainingDTO>(training);
        }
    }
}
