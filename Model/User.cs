using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitSearch_cs.Model
{
    public class User
    {

        private UserContext context;
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


    }
}
