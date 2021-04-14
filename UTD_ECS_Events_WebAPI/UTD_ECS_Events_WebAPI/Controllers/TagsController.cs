using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTD_ECS_Events_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet("all")]
        public ActionResult<List<TagModel>> GetAll()
        {
            var events = _tagsService.GetTags();
            return events.ToList();
        }

        [HttpPut]
        [Authorize]
        public string Put([FromBody] TagModel tagModel)
        {
            return _tagsService.UpdateTag(tagModel);
        }

        [HttpPost]
        [Authorize]
        public string Post([FromBody] TagModel tagModel)
        {
            return _tagsService.CreateTag(tagModel);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(string id)
        {
            _tagsService.DeleteTag(id);
        }
    }
}
