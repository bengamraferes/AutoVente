using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Insight
{
    public class DontValues
    {
        public string label { get; set; }
        public int value { get; set; }

        public DontValues(string Label, int Value)
        {
            label = Label;
            value = Value;
        }
    }
}