using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TeknikServis.Models.Interfaces;

namespace TeknikServis.Models
{
    public class BrokenDevice : IUnique
    {
     
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SerialNo { get; set; }
        public bool isGaranti { get; set; }
  
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual BrokenDeviceDetail BrokenDeviceDetail { get; set; }
        public virtual Shipment Shipment { get; set; }









    }
}