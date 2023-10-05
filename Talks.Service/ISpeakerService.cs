using Talks.Service.Models;

namespace Talks.Service
{
    public interface ISpeakerService
    {
        /// <summary>
        /// Gets a Location Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        Task<SpeakerDTO?> GetSpeakerAsync(Guid talkReferenceId, string code);
    }
}
