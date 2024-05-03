using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class SecureNotesModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public byte[] SecureNote { get; set; }
        
        //// Aes Key, IV and Data Identifier
        //public byte[] KeyData { get; set; }
        //public byte[] IVData { get; set; }
        //public string Identifier { get; set; }
    }
}
