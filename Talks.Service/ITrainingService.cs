using Talks.Service.Models;

namespace Talks.Service
{
    public interface ITrainingService
    {
        /// <summary>
        /// Gets All Trainings Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        Task<IEnumerable<TrainingDTO>> GetAllTrainingsAsync(Guid talkReferenceId);

        /// <summary>
        /// Gets a Training Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        Task<TrainingDTO?> GetTrainingAsync(Guid talkReferenceId, string code);
    }
}
