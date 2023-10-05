using Talks.Service.Models;

namespace Talks.Service
{
    public interface ISpeakerService
    {
        /// <summary>
        /// Gets a Location Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        Task<SpeakerDTO> GetSpeakerAsync(int talkId, string code);
    }
}
