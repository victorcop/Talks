using Talks.Service.Models;

namespace Talks.Service
{
    public interface ITalkService
    {
        /// <summary>
        /// Gets Talks Async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TalkDTO>> GetTalksAsync();

        /// <summary>
        /// Gets Talk Async
        /// </summary>
        /// <param name="TalkReferenceId">Talk Reference Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"</returns>
        Task<TalkDTO> GetTalkAsync(Guid TalkReferenceId);

        /// <summary>
        /// Adds Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="TalkDTO"/></param>
        /// <returns>Object of the type <see cref="TalkCreationDTO"/></returns>
        Task<TalkDTO> AddTalkAsync(TalkCreationDTO talk);

        /// <summary>
        /// Updates a Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="TalkDTO"/></param>
        /// <returns>Object of the type <see cref="TalkUpdateDTO"/></returns>
        Task<TalkDTO> UpdateTalkAsync(TalkUpdateDTO talk);
    }
}
