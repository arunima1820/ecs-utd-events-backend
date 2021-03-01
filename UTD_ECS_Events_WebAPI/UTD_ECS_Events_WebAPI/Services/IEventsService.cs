using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Services
{
    public interface IEventsService
    {
        IEnumerable<EventModel> GetEvents();
        IEnumerable<EventModel> GetEventsByDate(DateTime start, DateTime end);
        EventModel GetSingleEvent(string id);
        IEnumerable<EventModel> GetEventsByOrg(string org);
        string UpdateEvent(EventModel eventModel);
        string CreateEvent(EventModel eventModel);
        void DeleteEvent(string id);
    }
}

