using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Product: Concept
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date), 
            Display(Name ="Production Date")]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage ="Name Required"), 
            StringLength(25, ErrorMessage ="Name must have 25 caracters"), MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
       // [ForeignKey("Category")]
        public int? CategoryRef { get; set; }
        public virtual List<Provider> Providers { get; set; }
        [ForeignKey("CategoryRef")]
        public virtual Category Category { get; set; }
        public virtual IList<Facture> Factures { get; set; }

        public virtual IList<Client> Clients { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("Je suis un produit");
        }

        public override string ToString()
        {
            return $" Produit [{Name}, {Price},{Quantity}] ";
        }
    }
}
