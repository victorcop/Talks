using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Talks.Data.Repositories;
using Talks.Domain;
using Talks.Service.Models;

namespace Talks.Service
{
    public class TalkService : ITalkService
    {

        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;
        private ILogger<TalkService> _logger;

        public TalkService(ITalkRepository talkRepository, IMapper mapper, ILogger<TalkService> logger)
        {
            _talkRepository = talkRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TalkDTO>> GetTalksAsync()
        {
            var talks = await _talkRepository.GetTalksAsync();

            _logger.LogInformation($"Talks fetched.");

            if (talks == null || !talks.Any())
            {
                _logger.LogInformation($"Talks not found.");
                return Enumerable.Empty<TalkDTO>();
            }

            return _mapper.Map<IEnumerable<TalkDTO>>(talks);
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> GetTalkAsync(Guid talkReferenceId)
        {
            var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

            if (talk == null)
            {
                _logger.LogInformation($"Talks not found.");
                return null;
            }

            _logger.LogInformation($"Talk {0} fetched.", talk.TalkReferenceId);

            return _mapper.Map<TalkDTO>(talk);
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> AddTalkAsync(TalkCreationDTO talk)
        {
            var lastTalkId = _talkRepository.GetLastTalkId();

            var finalTalk = _mapper.Map<Talk>(talk);

            finalTalk.TalkId = ++lastTalkId;
            finalTalk.TalkReferenceId = Guid.NewGuid();

            var createdTalk = await _talkRepository.AddTalkAsync(finalTalk);

            _logger.LogInformation($"Talk {createdTalk.TalkId} created.");

            return _mapper.Map<TalkDTO>(createdTalk);
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> UpdateTalkAsync(TalkUpdateDTO talk)
        {

            var talkToUpdate = _mapper.Map<Talk>(talk);

            var talkUpdated = await _talkRepository.UpdateTalkAsync(talkToUpdate);

            _logger.LogInformation($"Talk {talk.TalkReferenceId} updated.");

            return _mapper.Map<TalkDTO>(talkUpdated);
        }
    }
}
