using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sm_coding_challenge.Models;
using sm_coding_challenge.Services.DataProvider;

namespace sm_coding_challenge.Controllers
{
    public class HomeController : Controller
    {

        private IDataProvider _dataProvider;
        public HomeController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public async Task<IActionResult> Index()
        {
            await _dataProvider.UpsertPlayers();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Player(string id)
        {
            var player = await _dataProvider.GetPlayerById(id);
            return Json(player);
        }

        [HttpGet]
        public async Task<IActionResult> Players(string ids)
        {
            var idList = ids.Split(',').Distinct();

            var returnList = new List<dynamic>();
            foreach (var id in idList)
            {
                var player = await _dataProvider.GetPlayerById(id);
                returnList.Add(player);
            }
            return Json(returnList);
        }

        [HttpGet]
        public async Task<IActionResult> AllPlayers()
        {

            var players = await _dataProvider.AllPlayers();

            return Json(players);
        }

        [HttpGet]
        public async Task<IActionResult> LatestPlayers(string ids)
        {
            var players = await _dataProvider.LatestPlayers(ids);

            return Json(players);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
