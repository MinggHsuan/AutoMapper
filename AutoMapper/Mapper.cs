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
                object dict = new Dictionary<int, int>();
                //ValueType valueType = Extend.FindType(destprop.PropertyType);
                ValueType valueType = Extend.FindType(dict.GetType());
                if (destprop == null)
                {
                    continue;
                }

                else if (valueType == ValueType.ListType)
                {
                    Type sourceType = sourceProp.GetValue(source).GetType();
                    bool sourceIsEnumerable = sourceType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    bool destIsEnumerable = destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    var sourceArgsType = sourceProp.PropertyType.GetGenericArguments();
                    var destArgsType = destType.GetGenericArguments();

                    var noArgsList = destType.GetGenericTypeDefinition();
                    var destList = noArgsList.MakeGenericType(destArgsType);
                    var destInstanceList = Activator.CreateInstance(destList);
                    IList list = (IList)destInstanceList;
                    ///測試
                    IEnumerable sourceList = (IEnumerable)sourceProp.GetValue(source);
                    IEnumerator enumerator = sourceList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var item = enumerator.Current;
                        MethodInfo method = destArgsType[0].GetMethod("Parse", new Type[] { sourceArgsType[0] });
                        var value = method.Invoke(null, new object[] { item });
                        list.Add(value);
                    }
                    destprop.SetValue(dest, list);
                }
                else if (valueType == ValueType.DictionaryType)
                {

                }
                else if (valueType == ValueType.ClassType)
                {

                }
                else if (valueType == ValueType.ArrayType)
                {

                }
                else if (valueType == ValueType.EnumType)
                {
                    destprop.SetValue(dest, Enum.Parse(destprop.PropertyType, sourceProp.GetValue(source).ToString()));
                }
                else
                {
                    MethodInfo method = destType.GetMethod("Parse", new Type[] { typeof(string) });
                    destprop.SetValue(dest, method.Invoke(null, new object[] { sourceProp.GetValue(source).ToString() }));
                }
            }
            return dest;
        }


    }
}
