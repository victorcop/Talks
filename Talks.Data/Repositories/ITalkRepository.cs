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
        /// <param name="TalkReferenceId">Talk Reference Id</param>
        /// <returns>Object of the type <see cref="Talk"/></returns>
        Task<Talk> GetTalkAsync(Guid TalkReferenceId);

        /// <summary>
        /// Adds Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="Talk"/></param>
        /// <returns>Object of the type <see cref="Talk"/></returns>
        Task<Talk> AddTalkAsync(Talk talk);

        /// <summary>
        /// Updates a Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="Talk"/></param>
        /// <returns>Object of the type <see cref="Talk"/></returns>
        Task<Talk> UpdateTalkAsync(Talk talk);

        /// <summary>
        /// Get Last Talk Id
        /// </summary>
        /// <returns>Id of the last talk</returns>
        int GetLastTalkId();
    }
}
