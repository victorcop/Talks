using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    /// <summary>
    /// Talks Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ITalkService _talkService;
        private readonly ILogger<TalksController> _logger;

        public TalksController(ITalkService talkService, ILogger<TalksController> logger)
        {
            _talkService = talkService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the talks Async
        /// </summary>
        /// <returns>IEnumerable of object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalkDTO>>> GetAsync()
        {
            try
            {
                var talks = await _talkService.GetTalksAsync();

                if (talks == null || !talks.Any())
                {
                    _logger.LogInformation($"Talks not found.");
                    return NoContent();
                }

                return Ok(talks);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting talks", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Gets a talk Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{talkId}", Name = "GetTalkAsync")]
        public async Task<ActionResult<TalkDTO>> GetTalkAsync(Guid talkId)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkId).ConfigureAwait(false);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkId} not found.");
                    return NotFound();
                }

                return Ok(talk);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Adds a talk Async
        /// </summary>
        /// <param name="TalkCreationDTO">Object of the type <see cref="TalkCreationDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="201">Created</response>
        /// <response code="204">Updated</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> CreateTalkAsync(TalkCreationDTO talk)
        {
            try
            {
                var createdTalk = await _talkService.AddTalkAsync(talk).ConfigureAwait(false);
                return CreatedAtRoute("GetTalkAsync", new { createdTalk.TalkId }, createdTalk);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while Creating talk.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Updates a talk Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="TalkUpdateDTO">Object of the type <see cref="TalkUpdateDTO"/></param>
        /// <response code="204">Updated</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpPut("{talkId}")]
        public async Task<IActionResult> UpdateTalkAsync(Guid talkId, TalkUpdateDTO talk)
        {
            try
            {
                var existingTalk = await _talkService.GetTalkAsync(talkId).ConfigureAwait(false);

                if (existingTalk == null)
                {
                    _logger.LogInformation($"Talk {talkId} not found.");
                    return NotFound();
                }

                await _talkService.UpdateTalkAsync(talkId, talk).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while updating talk {talkId}.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Patch Talk Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="patchDocument">JsonPatchDocument of the type <see cref="TalkToUpdateDTO"/></param>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpPatch("{talkId}")]
        public async Task<IActionResult> PartialyUpadteTalkAsync(Guid talkId, JsonPatchDocument<TalkToUpdateDTO> patchDocument)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkId).ConfigureAwait(false);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkId} not found.");
                    return NotFound();
                }

                var talkToPatch = new TalkToUpdateDTO
                {
                    Abstract = talk.Abstract,
                    Title = talk.Title,
                    Level = talk.Level
                };

                patchDocument.ApplyTo(talkToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Bad Request", patchDocument);
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(talkToPatch))
                {
                    _logger.LogInformation($"Bad Request", talkToPatch);
                    return BadRequest(ModelState);
                }

                var talkUpdateDTO = new TalkUpdateDTO
                {
                    Abstract = talkToPatch.Abstract,
                    Title = talkToPatch.Title,
                    Level = talkToPatch.Level
                };

                await _talkService.UpdateTalkAsync(talkId, talkUpdateDTO).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while patching talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Delete Talk Async
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <response code="404">Not Found</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpDelete("{talkId}")]
        public async Task<IActionResult> DeleteTalkAsync(Guid talkId)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkId).ConfigureAwait(false);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkId} not found.");
                    return NotFound();
                }

                await _talkService.DeleteTalkAsync(talkId).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while deleting talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
