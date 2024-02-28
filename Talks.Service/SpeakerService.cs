using AutoMapper;
using Microsoft.Extensions.Logging;
using Talks.Data.Repositories;
using Talks.Service.Models;

namespace Talks.Service
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ILogger<SpeakerService> _logger;
        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public SpeakerService(ITalkRepository talkRepository, IMapper mapper, ILogger<SpeakerService> logger)
        {
            _logger = logger;
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<SpeakerDTO?> GetSpeakerAsync(Guid talkReferenceId, Guid trainingReferenceId)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                if (talk == null) { return null; }

                var training = talk.Trainings.FirstOrDefault(t => t.TrainingId == trainingReferenceId);

                _logger.LogInformation($"Getting Speaker information for talk id: {talkReferenceId} and training: {trainingReferenceId}");

                var speaker = training?.Speaker;

                return _mapper.Map<SpeakerDTO>(speaker);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Getting Speaker information for talk id: {talkReferenceId} and training: {trainingReferenceId}, Error Message: {e.Message}");
                throw;
            }
        }
    }
}
