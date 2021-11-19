using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax.Models
{
    public class ClientOrders
    {
        public int Id { get; set; }
        public string ClientNom { get; set; }
        public int ClientId { get; set; }
        public string Nom { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public double Total { get; set; }
        public string DeliveryTime { get; set; }
        public int Quantite { get; set; }
    }
}
