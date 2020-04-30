using sm_coding_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sm_coding_challenge.Persistence.Repositories
{
    public interface IDataRepository
    {
        Task<int> UpsertPlayers();
        Task<dynamic> GetPlayerById(string id);

        Task<PlayerModel> AllPlayers();

        Task<PlayerModel> LatestPlayers(string ids);
    }
}
