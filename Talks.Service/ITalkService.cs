using Talks.Service.Models;

namespace Talks.Service
{
    public interface ITalkService
    {
        /// <summary>
        /// Gets Talks Async
        /// </summary>
        /// <returns></returns>
        IEnumerable<TalkDTO> GetTalksAsync();

        /// <summary>
        /// Gets Talk Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"</returns>
        TalkDTO GetTalkAsync(int talkId);
    }
}
