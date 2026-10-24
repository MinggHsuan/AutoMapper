using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueTypes
{
    internal class ClassType : AValueType
    {
        public override object Create(Type sourceType, object source, Type destType)
        {
            if (sourceType != destType)
            {
                return null;
            }

            MethodInfo method = typeof(Mapper).GetMethod("Map").MakeGenericMethod(sourceType, destType);
            return method.Invoke(null, new object[] { source });

        }
    }
}
