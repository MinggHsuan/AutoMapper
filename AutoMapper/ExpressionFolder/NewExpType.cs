using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class NewExpType : AExpressionType
    {
        public override object GetResult(object source, Expression sourceCallback)
        {
            NewExpression sourceNewExp = (NewExpression)sourceCallback;
            object result = null;
            foreach (Expression expItem in sourceNewExp.Arguments)
            {
                ExpressionType expressionType = expItem.FindExpType();
                Type type = Type.GetType($"AutoMapper.ExpressionFolder.{expressionType}");
                AExpressionType ExpressionInstance = (AExpressionType)Activator.CreateInstance(type);
                result = ExpressionInstance.GetResult(source, expItem);
            }
            return result;
        }


    }
}
