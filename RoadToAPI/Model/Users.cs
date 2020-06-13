using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadToAPI.Model
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

    }
}
