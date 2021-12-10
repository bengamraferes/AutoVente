using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class BaseService<T> where T : BaseEntity
    {
        protected SqlRepository<T> dao ;

        public BaseService()
        {
            dao = new SqlRepository<T>(new MyContext());
        }
        public virtual IQueryable<T> GetAll()
        {
            return dao.Collection();
        }

        public void Delete(int id)
        {
            dao.Delete(id);
        }

        public T FindById(int id)
        {
            return dao.FindById(id);
        }

        public void Insert(T t)
        {
           dao.Insert(t);
        }

        public void SaveChanges()
        {
            dao.SaveChanges();
        }

        public void Update(T t)
        {
            dao.Update(t);
        }
    }
}