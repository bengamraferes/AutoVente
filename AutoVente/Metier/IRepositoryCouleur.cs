using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVente.Metier
{
    public interface IRepositoryCouleur : IRepositoryNom<Couleur>
    {
        Couleur GetByCode(string CodeCouleur);
    }
}
