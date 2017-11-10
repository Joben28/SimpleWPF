using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Models.Cache
{
    public class AuthCache
    {
        //Some fake useless token
        public string AuthToken { get; set; } = "ABCD1234";
        //Some fake useless boolean
        public bool IsAuthorized { get; set; } = true;
        //A timeout value for the session, used to push user back to login.
        public DateTime Timeout { get; set; } = DateTime.Now.AddSeconds(30);
    }
}
