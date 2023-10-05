using Talks.Service.Models;

namespace Talks.Service
{
    public interface ITrainingService
    {
        /// <summary>
        /// Gets All Trainings Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        Task<IEnumerable<TrainingDTO>> GetAllTrainingsAsync(int talkId);

        /// <summary>
        /// Gets a Training Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        Task<TrainingDTO> GetTrainingAsync(int talkId, string code);
    }
}
