using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVente.Metier
{
    public interface IRepositoryVehicule: IRepository<Vehicule>
    {
        Vehicule FindByImmatriculation(string immatriculation);
        List<Vehicule> FindByKilometrage(int min, int max);
        List<Vehicule> FindByEtat(EtatVoiture etat);
    }
}
