using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TeknikServis.Models.Interfaces;

namespace TeknikServis.Models
{
    public enum WhichStep
    {
        Alındı,Teşhis,Tedarik,Onarım,Kargolama

    }
    public class BrokenDeviceDetail:IUnique
    {
     
        public int Id { get; set; }
        public string Issues { get; set; }
        public string Solution { get; set; }
        public WhichStep? WhichStep { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime EstimatedDate { get; set; }
    
       
        public virtual  BrokenDevice BrokenDevice { get; set; }

       
    }
}