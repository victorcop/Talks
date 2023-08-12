using AutoMapper;
using Talks.Data.Repositories;
using Talks.Service.Models;

namespace Talks.Service
{
    public class TrainingService : ITrainingService
    {

        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;

        public TrainingService(ITalkRepository talkRepository, IMapper mapper)
        {
            _talkRepository = talkRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IEnumerable<TrainingDTO> GetAllTrainingsAsync(int talkId)
        {
            var talk = _talkRepository.GetTalkAsync(talkId);

            var trainings = talk.Trainings;

            return _mapper.Map<IEnumerable<TrainingDTO>>(trainings);
        }

        /// <inheritdoc/>
        public TrainingDTO GetTrainingAsync(int talkId, string code)
        {
            var talk = _talkRepository.GetTalkAsync(talkId);

            var training = talk.Trainings.FirstOrDefault(t => t.Code == code);

            return _mapper.Map<TrainingDTO>(training);
        }
    }
}
