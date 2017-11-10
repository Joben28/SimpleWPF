using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSampleApplication.Models
{
    public class AccountModel
    {
        public int Id { get; set; } = 1;
        public string Username { get; set; } = "Dev001";
        public string Email { get; set; } = "Developer@email.com";
    }
}
