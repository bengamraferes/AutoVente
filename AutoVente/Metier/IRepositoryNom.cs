using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVente.Metier
{
    public interface IRepositoryNom<T> : IRepository<T> where T: BaseEntityNom
    {
       
        List<T> FindByKey(string key);
        T FindByNom(string nom);
    }
}
