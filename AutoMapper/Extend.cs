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
        public static ValueType FindType(Type destType)
        {

            if (destType.IsEnum)
            {
                return ValueType.EnumType;
            }
            else if (destType.IsArray)
            {
                return ValueType.ArrayType;
            }
            //else if (destType.IsGenericType && destType.GetInterfaces().Any(x => x.GetGenericTypeDefinition() == typeof(IDictionary)))
            //{
            //    return ValueType.DictionaryType;
            //}


            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary)))
            {
                return ValueType.DictionaryType;
            }
            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable)))
            {
                return ValueType.ListType;
            }
            else if (destType.IsClass)
            {
                return ValueType.ClassType;
            }
            else
            {
                return ValueType.BasicType;
            }
        }

    }
}
