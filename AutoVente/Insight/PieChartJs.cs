using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Insight
{
    public class PieChartJs
    {
        public string label { get; set; }
        public int value { get; set; }

        public PieChartJs(string Label, int value)
        {
            label = Label;
            this.value = value;
        }
    }
}