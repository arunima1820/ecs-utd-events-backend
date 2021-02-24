using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public interface IFirestoreRepository
    {
        Task<IEnumerable<TeamModel>> GetTeams();
        Task<string> CreateTeam(TeamModel teamModel);
        void DeleteTeam(string id);
    }
}
