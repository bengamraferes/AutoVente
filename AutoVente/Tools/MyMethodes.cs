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
                case "ESSENCE":
                    carburent = Carburent.ESSENCE;
                    break;
                case "GASOLE":
                    carburent = Carburent.GASOLE;
                    break;
                case "ELECTRIQUE":
                    carburent = Carburent.ELECTRIQUE; 
                    break;
                case "HYBRIDE":
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
                case "AUTO":
                    boiteVitesse = BoiteVitesse.AUTO;
                    break;
                case "MANUEL":
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
                case "BREAK":
                    type = Models.Type.BREAK;
                    break;
                case "CITADINE":
                    type = Models.Type.CITADINE;
                    break;
                case "ROUTIERE":
                    type = Models.Type.ROUTIERE;
                    break;
                case "SPROTIVE":
                    type = Models.Type.SPROTIVE;
                    break;
                case "MONOSPACE":
                    type = Models.Type.MONOSPACE;
                    break;
                case "SUV":
                    type = Models.Type.SUV;
                    break;
                case "LUDOSPACE":
                    type = Models.Type.LUDOSPACE;
                    break;
                case "BERLINE":
                    type = Models.Type.BERLINE;
                    break;


            }
            return type;
        }
    }
    //BREAK = 1,
    //    CITADINE = 2,
    //    ROUTIERE = 3,
    //    SPROTIVE = 4,
    //    MONOSPACE = 5,
    //    SUV = 6,
    //    LUDOSPACE = 7,
    //    BERLINE = 8
    //}
    //public class EnumCorrespond<T> where T : Enum
    //{
    //    public T EnumBdd { get; set; }
    //    public System.Type t = typeof(T);
    //    public EnumCorrespond(T enumBdd)
    //    {
    //        EnumBdd = enumBdd;
    //    }

        //public T CorrespondEnum(string valueEnum)
        //{
        //    //Enum.GetNames
        //    //return T;

        //    T res;
        //    foreach (int item in Enum.GetValues(t))
        //    {

        //        if (Enum.GetName(t, item) == valueEnum)
        //        {

        //            res = item;
        //        }
        //    }
        //    return res;

    //    //}
    //}
}