using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Tools
{

    public static class MyMethodes
    {
        public static Carburent GetValueCarburent(string enumVueValue)
        {
         
            Carburent carburent = 0;
            switch (enumVueValue)
            {
                case "Essence":
                    carburent = Carburent.ESSENCE;
                    break;
                case "Gasole":
                    carburent = Carburent.GASOLE;
                    break;
                case "Electrique":
                    carburent = Carburent.ELECTRIQUE;
                    break;
                case "Hybride":
                    carburent = Carburent.HYBRIDE;
                    break;

            }
            return carburent;
        }
        public static BoiteVitesse GetValueBoiteVitesse(string enumVueValue)
        {

            BoiteVitesse boiteVitesse = 0;
            switch (enumVueValue)
            {
                case "Automatique":
                    boiteVitesse = BoiteVitesse.AUTO;
                    break;
                case "Manuel":
                    boiteVitesse = BoiteVitesse.MANUEL;
                    break;

            }
            return boiteVitesse;
        }
        public static Models.Type GetValueType (string enumVueValue)
        {

            Models.Type type = 0;
            switch (enumVueValue)
            {
                case "Breack":
                    type = Models.Type.BREAK;
                    break;
                case "Citadine":
                    type = Models.Type.CITADINE;
                    break;
                case "Routiere":
                    type = Models.Type.ROUTIERE;
                    break;
                case "Sportive":
                    type = Models.Type.SPROTIVE;
                    break;
                case "Monospace":
                    type = Models.Type.MONOSPACE;
                    break;
                case "Suv":
                    type = Models.Type.SUV;
                    break;
                case "Ludospace":
                    type = Models.Type.LUDOSPACE;
                    break;
                case "Berline":
                    type = Models.Type.BERLINE;
                    break;

            }
            return type;
        }
    }

}