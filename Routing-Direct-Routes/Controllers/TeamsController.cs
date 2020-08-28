using Routing_Direct_Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing_Direct_Routes.Controllers
{
    public class TeamsController : ApiController
    {
        [HttpGet]
        [Route("api/teams/{id}")]
        public Team GetTeam(int id)
        {
            return new Team(id, $"Team{id}");
        }

        [HttpGet]
        [Route("api/teams")]
        public IEnumerable<Team> GetTeams()
        {
            return new List<Team> { Team.TeamA(), Team.TeamB() };
        }

        [HttpGet]
        [Route("api/teams/{teamId}/players")]
        public IEnumerable<Player> GetPlayers(int teamId)
        {
            return new List<Player> { Player.PlayerA(), Player.PlayerB() };
        }


    }
}
