using AutoMapper;
using Microsoft.Extensions.Logging;
using Talks.Data.Repositories;
using Talks.Domain;
using Talks.Service.Models;

namespace Talks.Service
{
    public class TalkService : ITalkService
    {

        private readonly ITalkRepository _talkRepository;
        private readonly IMapper _mapper;
        private ILogger<TalkService> _logger;

        public TalkService(ITalkRepository talkRepository, IMapper mapper, ILogger<TalkService> logger)
        {
            _talkRepository = talkRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TalkDTO>> GetTalksAsync()
        {
            try
            {
                var talks = await _talkRepository.GetTalksAsync();

                _logger.LogInformation($"Talks fetched.");

                if (talks == null || !talks.Any())
                {
                    _logger.LogInformation($"Talks not found.");
                    return Enumerable.Empty<TalkDTO>();
                }

                return _mapper.Map<IEnumerable<TalkDTO>>(talks);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error fetching Talks, Error Message: {e.Message}");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<TalkDTO?> GetTalkAsync(Guid talkReferenceId)
        {
            try
            {
                var talk = await _talkRepository.GetTalkAsync(talkReferenceId);

                if (talk == null)
                {
                    _logger.LogInformation($"Talks not found.");
                    return null;
                }

                _logger.LogInformation($"Talk {talk.TalkId} fetched.");

                return _mapper.Map<TalkDTO>(talk);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error fetching Talk: {talkReferenceId}, Error Message: {e.Message}");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<TalkDTO> AddTalkAsync(TalkCreationDTO talk)
        {
            try
            {
                var finalTalk = _mapper.Map<Talk>(talk);

                finalTalk.TalkId = Guid.NewGuid();

                var createdTalk = await _talkRepository.AddTalkAsync(finalTalk);

                _logger.LogInformation($"Talk {createdTalk?.TalkId} created.");

                return _mapper.Map<TalkDTO>(createdTalk);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error adding Talk, Error Message: {e.Message}");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<TalkDTO?> UpdateTalkAsync(Guid TalkReferenceId, TalkUpdateDTO talk)
        {
            try
            {
                var talkToUpdate = _mapper.Map<Talk>(talk);

                talkToUpdate.TalkId = TalkReferenceId;

                var talkUpdated = await _talkRepository.UpdateTalkAsync(talkToUpdate);

                _logger.LogInformation($"Talk {TalkReferenceId} updated.");

                return _mapper.Map<TalkDTO>(talkUpdated);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error updating Talk, Error Message: {e.Message}");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task DeleteTalkAsync(Guid talkReferenceId)
        {
            try
            {
                await _talkRepository.DeleteTalkAsync(talkReferenceId);

                _logger.LogInformation($"Talk {talkReferenceId} Delted.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Deleting Talk, Error Message: {e.Message}");
                throw;
            }
        }
    }
}
