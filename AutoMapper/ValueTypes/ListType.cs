using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class ListType : AValueType
    {
        //public override object Create(PropertyInfo sourceProp, object source, PropertyInfo destprop)
        //{
        //    Type sourceType = sourceProp.GetValue(source).GetType();
        //    bool sourceIsEnumerable = sourceType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        //    bool destIsEnumerable = destprop.PropertyType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        //    var sourceArgsType = sourceProp.PropertyType.GetGenericArguments();
        //    var destArgsType = destprop.PropertyType.GetGenericArguments();

        //    var noArgsList = destprop.PropertyType.GetGenericTypeDefinition();
        //    var destList = noArgsList.MakeGenericType(destArgsType);
        //    var destInstanceList = Activator.CreateInstance(destList);
        //    IList list = (IList)destInstanceList;

        //    IEnumerable sourceList = (IEnumerable)sourceProp.GetValue(source);
        //    IEnumerator enumerator = sourceList.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        var item = enumerator.Current;
        //        item.GetType().GetProperties();
        //        Mapper.Convert(sourceArgsType[0].p, item, destArgsType[0]);
        //        //MethodInfo method = destArgsType[0].GetMethod("Parse", new Type[] { sourceArgsType[0] });
        //        //var value = method.Invoke(null, new object[] { item });
        //        //list.Add(value);
        //    }
        //    return list;
        //}

        public override object Create(Type sourceType, object source, Type destType)
        {
            IList list = null;
            bool sourceIsEnumerable = sourceType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            bool destIsEnumerable = destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if (sourceIsEnumerable && destIsEnumerable)
            {
                var sourceArgsType = sourceType.GetGenericArguments();
                var destArgsType = destType.GetGenericArguments();

                var noArgsList = destType.GetGenericTypeDefinition();
                var destList = noArgsList.MakeGenericType(destArgsType);
                var destInstanceList = Activator.CreateInstance(destList);
                list = (IList)destInstanceList;

                IEnumerable sourceList = (IEnumerable)source;
                IEnumerator enumerator = sourceList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(Mapper.Convert(sourceArgsType[0], enumerator.Current, destArgsType[0]));
                }
            }
            return list;
        }
    }
}
