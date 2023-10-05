using AutoMapper;
using Talks.Data.Repositories;
using Talks.Domain;
using Talks.Service.Models;

namespace Talks.Service
{
    public class TalkService : ITalkService
    {

        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public TalkService(ITalkRepository talkRepository, IMapper mapper)
        {
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TalkDTO>> GetTalksAsync()
        {
            var talks = await _talkRepository.GetTalksAsync();

            return _mapper.Map<IEnumerable<TalkDTO>>(talks);
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> GetTalkAsync(int talkId)
        {
            var talk = await _talkRepository.GetTalkAsync(talkId);

            return _mapper.Map<TalkDTO>(talk);
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> AddTalkAsync(TalkCreationDTO talk)
        {
            var lastTalkId = _talkRepository.GetLastTalkId();

            var finalTalk = _mapper.Map<Talk>(talk);

            finalTalk.TalkId = ++lastTalkId;

            var createdTalk = await _talkRepository.AddTalkAsync(finalTalk);

            return _mapper.Map<TalkDTO>(createdTalk);
        }
    }
}
