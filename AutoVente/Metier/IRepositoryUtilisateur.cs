using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVente.Metier
{
    public interface IRepositoryUtilisateur : IRepositoryNom<Utilisateur>
    {
        Utilisateur GetByEmail(string email);
        Utilisateur GetByTelephone(string telephone);
    }
}
