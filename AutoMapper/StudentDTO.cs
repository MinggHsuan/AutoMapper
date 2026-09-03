using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class StudentDTO
    {
        public List<int> strings { get; set; }
        public char Name { get; set; }
        public string Class { get; set; }
        public StudentType Number { get; set; }
        public StudentDTO(char name, string Class, StudentType number, List<int> ints)
        {
            this.Name = name;
            this.Class = Class;
            this.Number = number;
            this.strings = ints;
        }

        public StudentDTO()
        {
        }
    }
}
