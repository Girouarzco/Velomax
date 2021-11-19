using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string ProductNumber { get; set; }
        public string Description { get; set; }
        public string Fournisseur { get; set; }
        public int FournisseurId { get; set; }
        public string Grandeur { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
        public string IntroductionDate { get; set; }
        public string DiscontinuationDate { get; set; }
    }
}
