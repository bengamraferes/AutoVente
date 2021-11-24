using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{

    public class AdresseService : BaseService<Adresse>
    {
        private SqlRepositoryAdresse daoAdresse;
        public AdresseService()
        {
            daoAdresse = new SqlRepositoryAdresse(new MyContext());
        }

        public Adresse GetByIdUtilisateur(int idUtilisateur)
        {
            return daoAdresse.GetByIdUtilisateur(idUtilisateur);
        }
    }
}