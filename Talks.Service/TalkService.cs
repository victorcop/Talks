using AutoMapper;
using Talks.Data.Repositories;
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
        public IEnumerable<TalksDTO> GetTalksAsync()
        {
            var talks = _talkRepository.GetTalksAsync();

            return _mapper.Map<IEnumerable<TalksDTO>>(talks);
        }
    }
}
