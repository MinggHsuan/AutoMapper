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
    internal class DictionaryType : AValueType
    {

        public override object Create(Type sourceType, object source, Type destType)
        {
            var sourceArgsType = sourceType.GetGenericArguments();
            var destArgsType = destType.GetGenericArguments();
            var sourceGenericType = sourceType.GetGenericTypeDefinition();
            var destGenericType = destType.GetGenericTypeDefinition();
            if (sourceGenericType == destGenericType && sourceArgsType[0] == destArgsType[0])
            {
                var noArgsDict = destType.GetGenericTypeDefinition();
                var emptyDestDict = noArgsDict.MakeGenericType(destArgsType);
                var destInstanceDict = Activator.CreateInstance(emptyDestDict);
                IDictionary destDict = (IDictionary)destInstanceDict;

                IDictionary sourceDict = (IDictionary)source;
                IEnumerator enumerator = sourceDict.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DictionaryEntry item = (DictionaryEntry)enumerator.Current;
                    var value = Mapper.Convert(sourceArgsType[1], item.Value, destArgsType[1]);
                    destDict.Add(item.Key, value);
                }
                return destDict;
            }

            return null;
        }

    }
}
