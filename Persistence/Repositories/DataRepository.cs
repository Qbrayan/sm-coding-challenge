using sm_coding_challenge.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using sm_coding_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class DataRepository :IDataRepository
    {
        protected readonly AppDbContext _context;

        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);
        public DataRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpsertPlayers()
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            //var currentTime = _context.Games.FirstOrDefault().TimeStamp;
            //var date = (DateTime.Now -currentTime).TotalDays;
            //if (date > 7)
            //{
            //    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE[Games]");
            //    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE[Rushers]");
            //    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE[Passers]");
            //    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE[Receivers]");
            //    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE[Kickers]");
            //}

            dynamic dataResponse;
            using (var client = new HttpClient(handler))
            {
                client.Timeout = Timeout;
                var stringData = await client.GetStringAsync("https://gist.githubusercontent.com/RichardD012/a81e0d1730555bc0d8856d1be980c803/raw/3fe73fafadf7e5b699f056e55396282ff45a124b/basic.json");
                dataResponse = JsonConvert.DeserializeObject<DataResponseModel>(stringData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }
            dataResponse.TimeStamp = DateTime.Now;

            _context.Games.Add(dataResponse);
            IEnumerable<RushingModel> r = dataResponse.Rushing;
            _context.Rushers.AddRange(r);
            IEnumerable<PassingModel> p = dataResponse.Passing;
            _context.Passers.AddRange(p);
            IEnumerable<ReceivingModel> c = dataResponse.Receiving;
            _context.Receivers.AddRange(c);
            IEnumerable<KickingModel> k = dataResponse.Kicking;
            _context.Kickers.AddRange(k);

            await _context.SaveChangesAsync();
            _context?.Dispose();
            //_context = new YourDbContext();



            return 0;
        }


        public async Task<dynamic> GetPlayerById(string id)
        {
            dynamic player;
            player = await _context.Rushers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (player == null)
            {
                player = await _context.Passers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            if (player == null)
            {
                player = await _context.Receivers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            if (player == null)
            {
                player = await _context.Kickers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }

            return player;
        }

        public async Task<PlayerModel> AllPlayers()
        {
            var players = new PlayerModel
            {
                Rushing = await _context.Rushers.ToListAsync(),
                Passing = await _context.Passers.ToListAsync(),
                Receiving = await _context.Receivers.ToListAsync(),
                Kicking = await _context.Kickers.ToListAsync()
            };
            return players;
        }

        public async Task<PlayerModel> LatestPlayers(string ids)
        {
            var idList = ids.Split(',').Distinct();
            var players = new PlayerModel
            {
                Rushing = await _context.Rushers.Where(x=> idList.Contains(x.Id)).ToListAsync(),
                Passing = await _context.Passers.Where(x => idList.Contains(x.Id)).ToListAsync(),
                Receiving = await _context.Receivers.Where(x => idList.Contains(x.Id)).ToListAsync(),
                Kicking = await _context.Kickers.Where(x => idList.Contains(x.Id)).ToListAsync()
            };
            return players;


        }


    }
}
