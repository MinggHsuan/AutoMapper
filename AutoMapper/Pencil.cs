using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Pencil
    {
        public string color { get; set; }
        public int price { get; set; }
        public string length { get; set; }
        public Rule rule { get; set; }
        public Dictionary<string, Rule> keyValues { get; set; }


        public Pencil(string color, int price, string length, Dictionary<string, Rule> keyValues)
        {
            this.color = color;
            this.price = price;
            this.length = length;
            this.keyValues = keyValues;
        }

        public Pencil(string color, int price, string length, Rule rule)
        {
            this.color = color;
            this.price = price;
            this.length = length;
            this.rule = rule;
        }
        public Pencil()
        {
        }
    }
}
