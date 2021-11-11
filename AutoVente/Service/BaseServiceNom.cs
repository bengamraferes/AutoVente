using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class BaseServiceNom<T> : BaseService<T> where T : BaseEntityNom
    {
        protected SqlRepositoryNom<T> daoNom;
        public BaseServiceNom()
        {
            daoNom = new SqlRepositoryNom<T>(new MyContext());
        }

        List<T> FindByNom(string nom)
        {
           return  daoNom.FindByNom(nom);
        }
    }
}