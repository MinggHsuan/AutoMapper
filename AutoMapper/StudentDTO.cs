using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class StudentDTO
    {
        //public List<Rule> strings { get; set; }
        //public Dictionary<string, int> strings { get; set; }
        //public Package package { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public StudentType Number { get; set; }
        public StudentDTO(string name, int Class, StudentType number)
        {
            this.Name = name;
            this.Class = Class;
            this.Number = number;
            //this.package = package;
        }
        //public StudentDTO(string name, int Class, StudentType number, /*Dictionary<string, int> ints*/)
        //{
        //    this.Name = name;
        //    this.Class = Class;
        //    this.Number = number;
        //    //this.strings = ints;
        //}
        public StudentDTO()
        {
        }
    }
}
