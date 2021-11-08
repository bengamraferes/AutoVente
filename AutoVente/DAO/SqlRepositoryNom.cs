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

        public T FindByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
