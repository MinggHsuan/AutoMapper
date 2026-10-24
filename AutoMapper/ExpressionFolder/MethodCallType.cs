using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class MethodCallType : AExpressionType
    {


        public override object GetResult(object source, Expression sourceCallback)
        {
            MethodCallExpression sourceMethodCall = (MethodCallExpression)sourceCallback;
            object[] objects = new object[sourceMethodCall.Arguments.Count];
            int count = 0;
            foreach (Expression expItem in sourceMethodCall.Arguments)
            {
                ExpressionType expressionType = expItem.FindExpType();
                Type type = Type.GetType($"AutoMapper.ExpressionFolder.{expressionType}");
                AExpressionType ExpressionInstance = (AExpressionType)Activator.CreateInstance(type);
                objects[count] = ExpressionInstance.GetResult(source, expItem);
                count++;
            }
            var obj = sourceMethodCall.Method.Invoke(sourceMethodCall.Method.Name, objects);
            return obj;
        }
    }
}
