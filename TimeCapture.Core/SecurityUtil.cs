using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace TimeCapture.Core
{
    public static class SecurityUtil
    {
        /// <summary>
        /// Creates the password hash.
        /// </summary>
        /// <param name="pwd">The PWD.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        public static string CreatePasswordHash(string password, string salt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
        }
    }
}
