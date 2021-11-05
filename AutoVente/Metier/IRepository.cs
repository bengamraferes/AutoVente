using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Metier
{
   
        public interface IRepository<T> where T : BaseEntity
    {
            IQueryable<T> Collection();
            T FindById(int id);
            void Delete(int id);
            void Insert(T t);
            void SaveChanges();
            void Update(T t);
        }
    
}