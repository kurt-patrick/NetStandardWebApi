using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing_Centralized_Routes.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Player() { }
        public Player(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static Player PlayerA() => new Player(1, "PlayerA");
        public static Player PlayerB() => new Player(2, "PlayerB");

    }
}