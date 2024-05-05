using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CardsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardholderName { get; set; }
        public byte[] CardNumber { get; set; }
        public string Brand { get; set; }
        public byte[] ExpirationMonth { get; set; }
        public byte[] ExpirationYear { get; set; }
        public byte[] SecurityCode { get; set; }

        
    }
}
