using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCapture.Service
{
    public interface IAccountService
    {
        bool ValidateUser(string emailAddress, string password);
    }
}
