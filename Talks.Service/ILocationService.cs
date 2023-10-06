using Talks.Service.Models;

namespace Talks.Service
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets a Location Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training Reference Id</param>
        /// <returns>Object of the type <see cref="LocationDTO"</returns>
        Task<LocationDTO?> GetLocationAsync(Guid talkReferenceId, Guid trainingReferenceId);
    }
}
