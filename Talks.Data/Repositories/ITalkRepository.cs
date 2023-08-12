using Talks.Domain;

namespace Talks.Data.Repositories
{
    public interface ITalkRepository
    {
        /// <summary>
        /// Gets Talks Async
        /// </summary>
        /// <returns>IEnumerable of object of the type <see cref="Talk"</returns>
        IEnumerable<Talk> GetTalksAsync();

        /// <summary>
        /// Gets Talk Async
        /// </summary>
        /// <param name="talkId"></param>
        /// <returns>Object of the type <see cref="Talk"</returns>
        Talk GetTalkAsync(int talkId);
    }
}
