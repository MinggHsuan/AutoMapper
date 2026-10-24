using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class StudentDAO
    {
        //public List<Rule> strings { get; set; }

        //public Dictionary<string, string> strings { get; set; }

        //public List<StudentDAO> strings { get; set; }
        //public Package package { get; set; }
        //public int Name1 { get; set; }
        public string Name1 { get; set; }
        //public object Name1 { get; set; }
        public string Class1 { get; set; }
        public int Number1 { get; set; }
        public bool Gender { get; set; }
        public StudentDAO(string name, string Class, int number)
        {
            this.Name1 = name;
            this.Class1 = Class;
            this.Number1 = number;
            this.Gender = false;
            //this.package = package;
        }
        //public StudentDAO(string name, string Class, int number, /*List<StudentDAO> strs*/)
        //{
        //    this.Name = name;
        //    this.Class = Class;
        //    this.Number = number;
        //    //this.strings = strs;
        //}
    }
}
