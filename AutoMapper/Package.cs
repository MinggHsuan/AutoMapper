using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Package
    {
        public List<Pencil> pencils { get; set; }
        public string score { get; set; }

        public List<string> strings { get; set; }

        public Package(string score, List<string> strings, List<Pencil> pencils)
        {
            this.score = score;
            this.strings = strings;
            this.pencils = pencils;
        }
        public Package()
        {

        }
    }
}
