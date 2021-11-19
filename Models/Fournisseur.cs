using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Siret { get; set; }
        public string CompanyNom { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Qualifiant { get; set; }
    }
}
