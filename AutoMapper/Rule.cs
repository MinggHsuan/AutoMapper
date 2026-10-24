using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Rule : IComparable<Rule>
    {
        public int width { get; set; }
        public int height { get; set; }

        public Rule(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Rule(int width)
        {
            this.width = width;
        }
        public Rule()
        {

        }

        public int CompareTo(Rule target)
        {
            if (this == null && target == null)
            {
                return 0;
            }
            else if (this == null)
            {
                return -1;
            }
            else if (target == null)
            {
                return 1;
            }
            else
            {
                return this.width.CompareTo(target.width);
            }
        }
    }
}
