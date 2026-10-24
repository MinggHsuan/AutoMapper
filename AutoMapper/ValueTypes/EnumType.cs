using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class EnumType : AValueType
    {
        public override object Create(Type sourceType, object source, Type destType)
        {
            return Enum.Parse(destType, source.ToString());
        }
    }
}
