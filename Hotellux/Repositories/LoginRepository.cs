using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class LoginRepository : ICRUD<LoginDataModel>
    {
        public void Create(LoginDataModel toCreate)
        {
            using var context = new Context();
            context.Logins.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(LoginDataModel toDelete)
        {
            using var context = new Context();
            context.Logins.Remove(toDelete);
            context.SaveChanges();
        }

        public IEnumerable<LoginDataModel> GetAll()
        {
            using var context = new Context();
            return context.Logins.AsEnumerable();
        }

        public void Update(LoginDataModel toUpdate)
        {
            using var context = new Context();
            context.Logins.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
