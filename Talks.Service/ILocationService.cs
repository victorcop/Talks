using Talks.Service.Models;

namespace Talks.Service
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets a Location Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="LocationDTO"</returns>
        Task<LocationDTO> GetLocationAsync(int talkId, string code);
    }
}
