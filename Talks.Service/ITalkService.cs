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
        Task<TalkDTO?> GetTalkAsync(Guid TalkReferenceId);

        /// <summary>
        /// Adds Talk Async
        /// </summary>
        /// <param name="talk">Object of the type <see cref="TalkCreationDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        Task<TalkDTO> AddTalkAsync(TalkCreationDTO talk);

        /// <summary>
        /// Updates a Talk Async
        /// </summary>
        /// <param name="TalkReferenceId">Talk Reference Id</param>
        /// <param name="talk">Object of the type <see cref="TalkUpdateDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        Task<TalkDTO?> UpdateTalkAsync(Guid TalkReferenceId, TalkUpdateDTO talk);

        /// <summary>
        /// Deletes a Talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>Returns Null if the task does not exists</returns>
        Task DeleteTalkAsync(Guid talkReferenceId);
    }
}