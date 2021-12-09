using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using Hotellux.Tools.Helpers;
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

        public List<LoginDataModel> GetAll()
        {
            using var context = new Context();
            return context.Logins.ToList();
        }

        public LoginDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Logins.SingleOrDefault(x => x.Id == id);
        }


        public void Update(LoginDataModel toUpdate)
        {
            using var context = new Context();
            context.Logins.Update(toUpdate);
            context.SaveChanges();
        }

        public LoginDataModel GetByLoginAndPassword(string login, string password) => GetAll().SingleOrDefault(x => x.Login == login && PasswordHasherHelper.Verify(password, x.Password));
    }
}
