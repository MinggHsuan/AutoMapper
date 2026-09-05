using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Extend
    {
        public static ValueEnumType FindType(Type destType)
        {

            if (destType.IsEnum)
            {
                return ValueEnumType.EnumType;
            }
            else if (destType.IsArray)
            {
                return ValueEnumType.ArrayType;
            }
            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary)))
            {
                return ValueEnumType.DictionaryType;
            }
            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable)))
            {
                return ValueEnumType.ListType;
            }
            else if (destType.IsClass)
            {
                return ValueEnumType.ClassType;
            }
            else
            {
                return ValueEnumType.BasicType;
            }
        }

    }
}
