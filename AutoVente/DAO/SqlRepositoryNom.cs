using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryNom<T> : SqlRepository<T>, IRepositoryNom<T> where T : BaseEntityNom
    {
        public SqlRepositoryNom(MyContext dataContext) : base(dataContext)
        {
        }

        public  List<T> FindByKey(string key)
        {
            List<T> liste = dbSet.AsNoTracking().Where(T => T.Nom.Contains(key)).OrderBy(T => T.Nom).ToList();
            return liste;
        }
        public T FindByNom(string nom)
        {
            return dbSet.AsNoTracking().SingleOrDefault(x => x.Nom == nom);
        }
    }
}
