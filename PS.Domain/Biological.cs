﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public  class Biological: Product
    {
        public string Herbs { get; set; }
        public override void GetMyType()
        {
            Console.WriteLine("Je suis un produit bio");
        }
    }
}
