using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Chemical:Product
    {

        public Address _Address { get; set; }
        public string LabName { get; set; }
        
        public override void GetMyType()
        {
            Console.WriteLine("Je suis un produit Chemique");
        }
    }
}
