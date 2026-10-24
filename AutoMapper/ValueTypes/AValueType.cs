using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal abstract class AValueType
    {

        public abstract object Create(Type sourceType, object source, Type destType);
    }
}
