using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class CustomerRepository : ICRUD<CustomerDataModel>
    {
        public ViewModels.CustomersViewModel CustomersViewModel
        {
            get => default;
            set
            {
            }
        }

        public void Create(CustomerDataModel toCreate)
        {
            using var context = new Context();
            context.Customers.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(CustomerDataModel toDelete)
        {
            using var context = new Context();
            context.Customers.Remove(toDelete);
            context.SaveChanges();
        }

        public List<CustomerDataModel> GetAll()
        {
            using var context = new Context();
            return context.Customers.ToList();
        }

        public CustomerDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Customers.SingleOrDefault(x => x.Id == id);
        }

        public void Update(CustomerDataModel toUpdate)
        {
            using var context = new Context();
            context.Customers.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
