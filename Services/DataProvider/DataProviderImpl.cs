using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sm_coding_challenge.Models;
using sm_coding_challenge.Persistence.Repositories;

namespace sm_coding_challenge.Services.DataProvider
{
    public class DataProviderImpl : IDataProvider
    {

        protected readonly IDataRepository _dataRepository;
        public DataProviderImpl(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<int> UpsertPlayers()
        {
            return await _dataRepository.UpsertPlayers();
        }
        public async Task<dynamic> GetPlayerById(string id)
        {
            return  await _dataRepository.GetPlayerById(id);
        }

        public async Task<PlayerModel> AllPlayers()
        {
            return await _dataRepository.AllPlayers();
        }

        public async Task<PlayerModel> LatestPlayers(string ids)
        {
            return await _dataRepository.LatestPlayers(ids);
        }
    }
}
