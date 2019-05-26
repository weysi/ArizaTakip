using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TeknikServis.Models.Interfaces;

namespace TeknikServis.Models
{
    public class Shipment:IUnique
    {
  
        
        public int Id { get; set; }
        public string ShipmentType { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string ShipmentAdress { get; set; }
        public virtual BrokenDevice BrokenDevice { get; set; }

        public Shipment()
        {
            ShipmentDate = DateTime.Today;
        }
    }
}