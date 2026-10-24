using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class ArrayType : AValueType
    {

        //public override object Create(PropertyInfo sourceProp, object source, PropertyInfo destprop)
        //{
        //    if (sourceProp.PropertyType.IsArray && destprop.PropertyType.IsArray)
        //    {
        //        Array sourceArray = (Array)sourceProp.GetValue(source);
        //        Type sourceElementType = sourceProp.PropertyType.GetElementType();
        //        Type destElementType = destprop.PropertyType.GetElementType();
        //        Array destArray = Array.CreateInstance(destElementType, sourceArray.Length);

        //        for (int i = 0; i < sourceArray.Length; i++)
        //        {
        //            string sourceElement = sourceArray.GetValue(i).ToString();
        //            destArray.SetValue(int.Parse(sourceElement), i);
        //        }
        //        return destArray;
        //    }

        //    return null;
        //}

        public override object Create(Type sourceType, object source, Type destType)
        {
            if (sourceType.IsArray && destType.IsArray)
            {
                Array sourceArray = (Array)source;
                //Type sourceElementType = sourceType.GetElementType();
                Type destElementType = destType.GetElementType();
                Array destArray = Array.CreateInstance(destElementType, sourceArray.Length);

                for (int i = 0; i < sourceArray.Length; i++)
                {
                    string sourceElement = sourceArray.GetValue(i).ToString();
                    destArray.SetValue(int.Parse(sourceElement), i);
                }
                return destArray;
            }

            return null;
        }
    }
}
