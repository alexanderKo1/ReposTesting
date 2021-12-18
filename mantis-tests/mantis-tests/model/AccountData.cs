using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AccountData
    {
        public AccountData()
        {
        }
        public AccountData(string username, string password)
        {
            this.Name = username;
            this.Password = password;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
