using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax.Models
{
    public class Velos
    {
        public int Id { get; set; }
        public string ModeleNum { get; set; }
        public string Nom { get; set; }
        public string Grandeur { get; set; }
        public string Ligne { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public string dateentree { get; set; }
        public string datefin { get; set; }
    }
}
