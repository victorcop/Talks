using Talks.Service.Models;

namespace Talks.Service
{
    public interface ISpeakerService
    {
        /// <summary>
        /// Gets a Location Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training Reference Id</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        Task<SpeakerDTO?> GetSpeakerAsync(Guid talkReferenceId, Guid trainingReferenceId);
    }
}
