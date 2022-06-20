using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
    public interface IFactureService:IService<Facture>
    {
        public List<Product> GetProdsByClient(Client client);
    }
}
