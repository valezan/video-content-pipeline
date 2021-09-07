

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoContentPipeline.Models;
using VideoContentPipeline.Models.Exceptions;
using VideoContentPipeline.Models.v1_0;
using VideoContentPipeline.Services;

namespace VideoContentPipeline.Controllers.v1_0
{
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class VideoController : Controller
    {
        private readonly IVideoService videoService;
        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]

        public async Task<IActionResult> Create(VideoMetaData data)
        {
            try
            {
                var result = await videoService.Create(data);
                return Ok(result);
            }
            catch(ArgumentNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(IdentityNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(Video), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = videoService.GetById(id);
                return Ok(result);
            }
            catch(VideoNotFoundException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(ArgumentNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(IdentityNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(IEnumerable<Video>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByTheme(string themeId)
        {
            try
            {
                var result = videoService.GetByThemeId(themeId);
                return Ok(result);
            }
            catch(ArgumentNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(VideoMetaData data)
        {
            try
            {
                var result = await videoService.Update(data);
                return Ok(result);
            }
            catch(ArgumentNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(IdentityNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(VideoNotFoundException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await videoService.Delete(id);
                return Ok(result);
            }
            catch(IdentityNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(VideoNotFoundException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateUrl(VideoLocation location)
        {
            try
            {
                var result = await videoService.UpdateVideoUrl(location);
                return Ok(result);
            }
            catch(IdentityNullException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }
            catch(VideoNotFoundException e)
            {
                return BadRequest(new ApiError(400, e.Message));
            }

            catch(Exception e)
            {
                return StatusCode(500, new ApiError(500, e.Message));
            }
        }
    }
}