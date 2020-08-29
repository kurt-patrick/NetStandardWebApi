using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Request_Throttling.Interfaces;
using Request_Throttling.Models;

namespace Request_Throttling.Repositories
{
    public class UserRepository : IUserStore
    {
        public User FindByUsername(string identifier) => new User() { Identifier = identifier };
    }
}