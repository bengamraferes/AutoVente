using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Extensions
{
    public class VehiculeComparer : IEqualityComparer<Vehicule>
    {
        public bool Equals(Vehicule x, Vehicule y)
        {
            return x.Immatriculation == y.Immatriculation;
        }

        public int GetHashCode(Vehicule obj)
        {
            return obj.Immatriculation.GetHashCode();
        }
    }
}