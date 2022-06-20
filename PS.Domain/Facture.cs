using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Facture
    {
       // [ForeignKey("Product")]
        public int ProductFk { get; set; }
        public int ClientFk { get; set; }
        public DateTime DateAchat { get; set; }
        public double Prix { get; set; }
       // [ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }       
        public virtual Product Product { get; set; }

    }
}
