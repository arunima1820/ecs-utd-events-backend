using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTD_ECS_Events_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet("all")]
        public ActionResult<List<EventModel>> GetAll()
        {
            var events = _eventsService.GetEvents();
            return events.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<EventModel> GetSingleEvent(string id)
        {
            try
            {
                return _eventsService.GetSingleEvent(id);
            }
            catch (Exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No event with ID = {0}", id)),
                    ReasonPhrase = "Event Id Not Found"
                };
                throw new System.Web.Http.HttpResponseException(resp);
            }
        }

        [HttpGet("date/start={start}&end={end}")]
        public ActionResult<List<EventModel>> GetEventsByDate(string start, string end)
        {
            try
            {
                DateTime startTime = start.Equals("none") ? DateTime.MinValue : DateTime.Parse(start);
                DateTime endTime = end.Equals("none") ? DateTime.MaxValue : DateTime.Parse(end);
                return _eventsService.GetEventsByDate(startTime, endTime).ToList();
            }
            catch(Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("StartTime and EndTime must be DateTime or \"?\". " +
                    "Format is yyyy-mm-ddThh:mm:ssZ"),
                    ReasonPhrase = "StartTime and/or EndTime is invalid"
                };
                throw new System.Web.Http.HttpResponseException(resp);
            }
        }

        [HttpGet("org={org}")]
        public ActionResult<List<EventModel>> GetEventsByOrg(string org)
        {
            var events = _eventsService.GetEventsByOrg(org);
            return events.ToList();
        }

        [HttpPut]
        public string Put([FromBody] EventModel eventModel)
        {
            return _eventsService.UpdateEvent(eventModel);
        }

        [HttpPost]
        public string Post([FromBody] EventModel eventModel)
        {
            return _eventsService.CreateEvent(eventModel);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _eventsService.DeleteEvent(id);
        }
    }
}
