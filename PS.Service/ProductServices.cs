using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServicePattern;
using PS.Data.Infrastructure;

namespace PS.Service
{

    public class ProductServices : Service<Product>, IProductService
    {

        public ProductServices(IUnitOfWork uwk):base(uwk)
        {

        }
        public void DeleteOldProducts()
        {

            //DateTime oldDate = DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0, 0));
            //var req = GetMany(p => p.DateProd < oldDate);


            DateTime dateNow = DateTime.Now;

            var products=GetMany().Where(p => dateNow.Subtract(p.DateProd).TotalDays > 365);

            foreach (var item in products)
            {
                Delete(item); 
            }
            Commit();
        }

        public List<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderBy(p => p.Price).Take(5).ToList();
        }

        //public List<Product> GetProdsByClient(Client c)
        //{
        //    FactureService factureService = new FactureService();
        //    return factureService.GetMany().Where(f => f.ClientFk == c.CIN)
        //        .Select(f => f.Product).ToList();
        //}

        public List<Product> GetProdsByClient()
        {
            throw new NotImplementedException();
        }

        public double UnavailableProductsPercentage()
        {
            int count = GetMany()
                .Where(p => p.Quantity == 0)
                .Count();
            return (double)count / GetMany().Count();
        }
    }
}
