using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PS.Domain
{
    public class Category
    {  [Key]     
        public int CategoryKey { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
