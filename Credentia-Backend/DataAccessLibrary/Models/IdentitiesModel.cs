using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class IdentitiesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Company { get; set; }
        public byte[] LicenseNumber { get; set; }
        public string Email { get; set; }
        public byte[] Phone { get; set; }
        public byte[] Address { get; set; }
        public byte[] Zip { get; set; }
        public string Country { get; set; }

    }
}
