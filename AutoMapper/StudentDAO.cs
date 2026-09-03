using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class StudentDAO
    {
        public List<string> strings { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Number { get; set; }

        public StudentDAO(string name, string Class, int number, List<string> strs)
        {
            this.Name = name;
            this.Class = Class;
            this.Number = number;
            this.strings = strs;
        }
    }
}
