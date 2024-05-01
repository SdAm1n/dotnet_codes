using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Helpers
{
    using BCrypt.Net;

    public class MasterPasswordHelper
    {
        // Hash Master Password
        public static string HashMasterPassword(string password)
        {
            return BCrypt.HashPassword(password, workFactor: 12);
        }

        // Verify Master Password
        public static bool VerifyMasterPassword(string hashedPassword, string storedHash)
        {
            return BCrypt.Verify(hashedPassword, storedHash);
        }
    }
}
