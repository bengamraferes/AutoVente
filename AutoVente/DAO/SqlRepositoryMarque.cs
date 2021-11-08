using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryMarque : SqlRepositoryNom<Marque>, IRepositoryMarque
    {
        public SqlRepositoryMarque(MyContext dataContext) : base(dataContext)
        {
        }

        public List<Vehicule> FidByOrigine(Origine origine)
        {
            throw new NotImplementedException();
        }
    }
}