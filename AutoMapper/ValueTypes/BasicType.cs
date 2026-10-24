using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class BasicType : AValueType
    {
        public override object Create(Type sourceType, object source, Type destType)
        {
            if (destType == typeof(string))
            {
                return source.ToString();
            }
            MethodInfo method = destType.GetMethod("Parse", new Type[] { typeof(string) });
            return method.Invoke(null, new object[] { source.ToString() });
        }
    }
}
