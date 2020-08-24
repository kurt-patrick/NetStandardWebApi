using Routing_Centralized_Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing_Centralized_Routes.Controllers
{
    public class TeamsController : ApiController
    {
        public Team GetTeam(int id)
        {
            return new Team(id, $"Team{id}");
        }

        public IEnumerable<Team> GetTeams()
        {
            return new List<Team> { Team.TeamA(), Team.TeamB() };
        }

        /// <summary>
        /// For this route to work, App_Start\WebApiConfig.cs must be updated with the custom route
        /// routeTemplate: "api/teams/{teamid}/players"
        /// 
        /// The problem with specialized routes such as this, is that they become artificially disconnected from the controller 
        /// and get mixed up with generic route definitions instead.
        /// And the bigger your application becomes, and the more complex your routing hierarchy is, the
        /// more likely you are to struggle with the maintenance and debugging of centralized routing.
        /// Therefore, it’s often a better option to move to direct routing instead
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public IEnumerable<Player> GetPlayers(int teamId)
        {
            return new List<Player> { Player.PlayerA(), Player.PlayerB() };
        }


    }
}
