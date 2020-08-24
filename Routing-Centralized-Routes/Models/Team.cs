using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing_Centralized_Routes.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Team() { }
        public Team(int id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }

        public static Team TeamA() => new Team(1, "TeamA");
        public static Team TeamB() => new Team(2, "TeamB");

    }
}