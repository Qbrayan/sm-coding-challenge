using sm_coding_challenge.Models;
using System.Threading.Tasks;

namespace sm_coding_challenge.Services.DataProvider
{
    public interface IDataProvider
    {
        Task<int> UpsertPlayers();
        Task<dynamic> GetPlayerById(string id);
        Task<PlayerModel> AllPlayers();

        Task<PlayerModel> LatestPlayers(string ids);
    }
}
