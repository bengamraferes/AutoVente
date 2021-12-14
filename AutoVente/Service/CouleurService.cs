using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class CouleurService : BaseService<Couleur>
    {
        private SqlRepositoryCouleur daoCouleur;
        public CouleurService()
        {
            daoCouleur = new SqlRepositoryCouleur(new MyContext());
        }

        public override IQueryable<Couleur> GetAll()
        {
            return daoCouleur.Collection();
        }

        public override Couleur FindById(int id)
        {
            return daoCouleur.FindById(id);
        }

        public Couleur FindByCode(string code)
        {
            return daoCouleur.GetByCode(code);
        }
        public List<Couleur> GetBlackAndwhite()
        {
            Couleur white = FindByCode("#FFFFFF");
            Couleur black = FindByCode("#000000");
            List<Couleur> lst = new List<Couleur>();
            lst.Add(black);
            lst.Add(white);
            return lst;


        }
    }
}