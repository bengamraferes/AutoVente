using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Insight
{
    public class BarValues
    {
        public string Date { get; set; }
        public int ChiffreAffaire { get; set; }

        public BarValues(string date, int chiffreAffaire)
        {
            Date = date;
            ChiffreAffaire = chiffreAffaire;
        }
    }
}