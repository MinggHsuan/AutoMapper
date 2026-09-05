using AutoMapper.ValueTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace AutoMapper
{
    internal class Mapper
    {
        public static TDest Map<TSource, TDest>(TSource source) where TDest : class, new()
        {
            var sourceProps = source.GetType().GetProperties();
            TDest dest = new TDest();
            foreach (var sourceProp in sourceProps)
            {
                var destprop = dest.GetType().GetProperty(sourceProp.Name);
                Type destType = destprop.PropertyType;
                //object dict = new Dictionary<int, int>();
                //var iii = dict.GetType();
                //ValueType valueType = Extend.FindType(destprop.PropertyType);
                //ValueEnumType valueType = Extend.FindType(destType.GetType());
                if (destprop == null)
                {
                    continue;
                }
                ValueEnumType valueEnum = Extend.FindType(destType);
                Type type = Type.GetType($"AutoMapper.ValueTypes.{valueEnum}");
                AValueType valueType =(AValueType)Activator.CreateInstance(type);
                valueType.Create();
                //else if (valueType == ValueEnumType.ListType)
                //{
                //    Type sourceType = sourceProp.GetValue(source).GetType();
                //    bool sourceIsEnumerable = sourceType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                //    bool destIsEnumerable = destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                //    var sourceArgsType = sourceProp.PropertyType.GetGenericArguments();
                //    var destArgsType = destType.GetGenericArguments();

                //    var noArgsList = destType.GetGenericTypeDefinition();
                //    var destList = noArgsList.MakeGenericType(destArgsType);
                //    var destInstanceList = Activator.CreateInstance(destList);
                //    IList list = (IList)destInstanceList;

                //    IEnumerable sourceList = (IEnumerable)sourceProp.GetValue(source);
                //    IEnumerator enumerator = sourceList.GetEnumerator();
                //    while (enumerator.MoveNext())
                //    {
                //        var item = enumerator.Current;
                //        MethodInfo method = destArgsType[0].GetMethod("Parse", new Type[] { sourceArgsType[0] });
                //        var value = method.Invoke(null, new object[] { item });
                //        list.Add(value);
                //    }
                //    destprop.SetValue(dest, list);
                //}
                //else if (valueType == ValueEnumType.DictionaryType)
                //{

                //}
                //else if (valueType == ValueEnumType.ClassType)
                //{

                //}
                //else if (valueType == ValueEnumType.ArrayType)
                //{

                //}
                //else if (valueType == ValueEnumType.EnumType)
                //{
                //    destprop.SetValue(dest, Enum.Parse(destprop.PropertyType, sourceProp.GetValue(source).ToString()));
                //}
                //else
                //{
                //    MethodInfo method = destType.GetMethod("Parse", new Type[] { typeof(string) });
                //    destprop.SetValue(dest, method.Invoke(null, new object[] { sourceProp.GetValue(source).ToString() }));
                //}
            }
            return dest;
        }


    }
}
