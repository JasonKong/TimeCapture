using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCapture.Service
{
    class AccountService : IAccountService
    {
        public bool ValidateUser(string emailAddress, string password)
        {
            return true;
        }
    }
}
