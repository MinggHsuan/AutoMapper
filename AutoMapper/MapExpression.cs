using AutoMapper.ExpressionFolder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class MapExpression<TSource, TDest>
    {
        public Dictionary<PropertyInfo, DestModel> destDict = new Dictionary<PropertyInfo, DestModel>();
        public object source;

        public MapExpression(object source)
        {
            this.source = source;
        }
        public void ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> sourceCallback, Expression<Func<TDest, TDestProp>> destCallback)
        {
            ExpressionType sourceExpressionType = sourceCallback.Body.FindExpType();
            Type type = Type.GetType($"AutoMapper.ExpressionFolder.{sourceExpressionType}");
            AExpressionType ExpressionInstance = (AExpressionType)Activator.CreateInstance(type);
            object obj = ExpressionInstance.GetResult(source, sourceCallback.Body);

            MemberExpression destMember = (MemberExpression)destCallback.Body;
            destDict.Add((PropertyInfo)destMember.Member, new DestModel(destCallback.Body.FindExpType(), obj));

        }

    }
}
