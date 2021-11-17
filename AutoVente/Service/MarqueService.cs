using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AutoVente.Service
{
    public class MarqueService : BaseServiceNom<Marque>
    {
        private SqlRepositoryMarque daoMarque;

        public MarqueService()
        {
            daoMarque = new SqlRepositoryMarque(new MyContext());
        }

        public List<Vehicule> FindByOrigine(Origine origine)
        {
            return daoMarque.FindByOrigine(origine);
        }

    }
}
