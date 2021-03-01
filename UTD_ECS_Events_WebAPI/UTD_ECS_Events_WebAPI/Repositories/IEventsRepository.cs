using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable<EventModel>> GetEvents();
        Task<List<EventModel>> GetEventsByDate(DateTime start, DateTime end);
        Task<string> CreateEvent(EventModel eventModel);
        Task<EventModel> GetSingleEvent(string id);
        Task<List<EventModel>> GetEventsByOrg(string org);
        Task<string> UpdateEvent(EventModel myEvent);
        void DeleteEvent(string id);
    }
}

