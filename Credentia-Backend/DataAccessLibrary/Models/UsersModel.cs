using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string MasterPassword { get; set; }
        public string Email { get; set; }
        public string User_Database { get; set; }
    }
}
