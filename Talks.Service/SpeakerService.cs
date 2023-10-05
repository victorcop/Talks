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
        public async Task<SpeakerDTO> GetSpeakerAsync(Guid talkReferenceId, string code)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

                _logger.LogInformation($"Getting Speaker information for task id: {0} and training: {1}", talkReferenceId, code);

                var speaker = training?.Speaker;

                return _mapper.Map<SpeakerDTO>(speaker);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Getting Speaker information for task id: {0} and training: {1}, Error Message: {2}", talkReferenceId, code, e.Message);
                throw;
            }
        }
    }
}
