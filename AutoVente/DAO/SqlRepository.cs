using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AutoVente.DAO
{
    public  class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal MyContext dataContext;

        internal DbSet<T> dbSet;

        public SqlRepository(MyContext dataContext)
        {
            this.dataContext = dataContext;

            dbSet = dataContext.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Delete(int id)
        {
            T t = FindById(id);

            if (dataContext.Entry(t).State == EntityState.Detached)
            {

                dbSet.Attach(t);
            }

            dbSet.Remove(t);
        }

        public T FindById(int id)
        {
            T obj = dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception($"{obj.GetType()} introuvable");
            }
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        public void Update(T t)
        {
            dbSet.Attach(t);

            dataContext.Entry(t).State = EntityState.Modified;
        }
    }
}