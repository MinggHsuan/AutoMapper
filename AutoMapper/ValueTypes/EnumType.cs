using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class EnumType : AValueType
    {
        public override void Create()
        {
            destprop.SetValue(dest, Enum.Parse(destprop.PropertyType, sourceProp.GetValue(source).ToString()));
        }
    }
}
