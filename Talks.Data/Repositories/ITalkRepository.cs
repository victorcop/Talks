using Talks.Domain;

namespace Talks.Data.Repositories
{
    public interface ITalkRepository
    {
        /// <summary>
        /// Gets Talks Async
        /// </summary>
        /// <returns>IEnumerable of object of the type <see cref="Talk"/></returns>
        Task<IEnumerable<Talk>> GetTalksAsync();

        /// <summary>
        /// Gets Talk Async
        /// </summary>
        /// <param name="talkId">talkId</param>
        /// <returns>Object of the type <see cref="Talk"/></returns>
        Task<Talk> GetTalkAsync(int talkId);

        /// <summary>
        /// Adds Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="Talk"/></param>
        /// <returns>Object of the type <see cref="Talk"/></returns>
        Task<Talk> AddTalkAsync(Talk talk);

        /// <summary>
        /// Get Last Talk Id
        /// </summary>
        /// <returns>Id of the last talk</returns>
        int GetLastTalkId();
    }
}
