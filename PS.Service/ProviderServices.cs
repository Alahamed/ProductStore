using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PS.Service
{
    public class ProviderServices
    {
        List<Provider> Providers;

        public ProviderServices(List<Provider> providers)
        {
            this.Providers = providers;
        }

        public List<Provider> GetProviderByName(string name)
        {
            //syntaxe de requete
            //var query = (from p in Providers
            //            where p.UserName.Contains(name)
            //            select p).ToList();
            //syntaxe des méthodes
            var query= Providers.Where(p=> p.UserName.Contains(name)).ToList();
            return query;
        }

        public void GetProviderByName2(string name)
        {
            //syntaxe de requete
            var query = (from p in Providers
                         where p.UserName.Contains(name)
                         select new { p.UserName, p.Email }).ToList();
            //syntaxe des méthodes
            var query2 = Providers
                .Where(p => p.UserName.Contains(name))
                .Select(p=>new {p.UserName,p.Email })
                .ToList();

            foreach (var item in query2)
            {
                Console.WriteLine($"[userName {item.UserName}, Email {item.Email}]");
            }
        }

        public Provider GetFirstProviderByName(string name)
        {
            //syntaxe de requete
            //var query = (from p in Providers
            //             where p.UserName.Contains(name)
            //             select p).First(); //FistOrDefault
            //return query;

            //sytaxe de méthodes
            var query2 = Providers
                .Where(p => p.UserName.Contains(name))
                .First();//FistOrDefault
            return query2;
        }

        public Provider GetProviderById(int id)
        {
            return Providers.Where(p => p.Id == id).SingleOrDefault();
        }
    }
}
