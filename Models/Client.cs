using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyNom { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string ContactPersonne { get; set; }
        public string Discount { get; set; }
        public string Fidelio { get; set; }
        public string Type { get; set; }
    }
}
