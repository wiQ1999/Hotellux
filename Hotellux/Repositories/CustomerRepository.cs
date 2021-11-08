using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellux.Repositories
{
    public class CustomerRepository : ICRUD<CustomerDataModel>
    {
        public void Create(CustomerDataModel toCreate)
        {
            using var context = new Context();
            context.Customers.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(CustomerDataModel toDelete)
        {
            using var context = new Context();
            context.Customers.Add(toDelete);
            context.SaveChanges();
        }

        public IEnumerable<CustomerDataModel> GetAll()
        {
            using var context = new Context();
            return context.Customers.AsEnumerable();
        }

        public void Update(CustomerDataModel toUpdate)
        {
            using var context = new Context();
            context.Customers.Add(toUpdate);
            context.SaveChanges();
        }
    }
}
