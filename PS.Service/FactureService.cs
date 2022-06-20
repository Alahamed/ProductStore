using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PS.Data.Infrastructure;

namespace PS.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public FactureService(IUnitOfWork uow):base(uow)
        {

        }
        public List<Product> GetProdsByClient(Client client)
        {
            return GetMany().Where(f=>f.ClientFk==client.CIN).Select(f=>f.Product).ToList();
        }
    }
}
