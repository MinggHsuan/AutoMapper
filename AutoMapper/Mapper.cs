using AutoMapper.ExpressionFolder;
using AutoMapper.ValueTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace AutoMapper
{
    internal class Mapper
    {

        public static TDest Map<TSource, TDest>(TSource source, Action<MapExpression<TSource, TDest>> action) where TDest : new()
        {
            var sourceProps = source.GetType().GetProperties();
            TDest dest = new TDest();

            foreach (var sourceProp in sourceProps)
            {
                PropertyInfo destprop = dest.GetType().GetProperty(sourceProp.Name);
                if (destprop == null)
                {
                    continue;
                }
                object destPropValue = Convert(sourceProp.PropertyType, sourceProp.GetValue(source), destprop.PropertyType);
                destprop.SetValue(dest, destPropValue);

            }

            var map = new MapExpression<TSource, TDest>(source);
            action.Invoke(map);
            if (map.destDict.Count != 0)
            {
                foreach (var item in map.destDict)
                {
                    object destPropValue = Convert(item.Value.sourceValue.GetType(), item.Value.sourceValue, item.Key.PropertyType);
                    item.Key.SetValue(dest, destPropValue);
                }
            }

            return dest;
        }

        public static object Convert(Type sourceType, object source, Type destType)
        {
            ValueEnumType valueEnum = destType.FindType();
            Type type = Type.GetType($"AutoMapper.ValueTypes.{valueEnum}");
            AValueType valueType = (AValueType)Activator.CreateInstance(type);
            return valueType.Create(sourceType, source, destType);
        }

    }
}
