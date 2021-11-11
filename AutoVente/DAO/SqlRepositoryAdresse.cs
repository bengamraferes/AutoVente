using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryAdresse : SqlRepository<Adresse>, IRepositoryAdresse
    {
        public SqlRepositoryAdresse(MyContext dataContext) : base(dataContext)
        {
        }

        public Adresse GetByIdUtilisateur(int idUtilisateur)
        {
            Adresse adresse = FindById(idUtilisateur);

            if (adresse != null)
            {
                return adresse;
            }
            else
            {
                throw new Exception("Adresse introuvable");
            }
        }
    }
}