using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Repositories;

namespace UTD_ECS_Events_WebAPI.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public IEnumerable<EventModel> GetEvents()
        {
            return _eventsRepository.GetEvents().Result;
        }

        public EventModel GetSingleEvent(string id)
        {
            return _eventsRepository.GetSingleEvent(id).Result;
        }

        public IEnumerable<EventModel> GetEventsByDate(DateTime start, DateTime end)
        {
            return _eventsRepository.GetEventsByDate(start.ToUniversalTime(), end.ToUniversalTime()).Result;
        }

        public IEnumerable<EventModel> GetEventsByOrg(string org)
        {
            return _eventsRepository.GetEventsByOrg(org).Result;
        }

        public string CreateEvent(EventModel eventModel)
        {
            return _eventsRepository.CreateEvent(eventModel).Result;
        }

        public void DeleteEvent(string id)
        {
            _eventsRepository.DeleteEvent(id);
        }
    }
}

