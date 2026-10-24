using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class ConditionalType : AExpressionType
    {
        public override object GetResult(object source, Expression sourceCallback)
        {
            ConditionalExpression sourceConditional = (ConditionalExpression)sourceCallback;
            ExpressionType binaryExpressionType = sourceConditional.Test.FindExpType();
            Type binaryType = Type.GetType($"AutoMapper.ExpressionFolder.{binaryExpressionType}");
            AExpressionType binaryInstance = (AExpressionType)Activator.CreateInstance(binaryType);
            object result = binaryInstance.GetResult(source, sourceConditional.Test);
            if ((bool)result)
            {
                ExpressionType trueExpressionType = sourceConditional.IfTrue.FindExpType();
                Type trueType = Type.GetType($"AutoMapper.ExpressionFolder.{trueExpressionType}");
                AExpressionType trueInstance = (AExpressionType)Activator.CreateInstance(trueType);
                result = trueInstance.GetResult(source, sourceConditional.IfTrue);
            }
            else
            {
                ExpressionType falseExpressionType = sourceConditional.IfFalse.FindExpType();
                Type falseType = Type.GetType($"AutoMapper.ExpressionFolder.{falseExpressionType}");
                AExpressionType falseInstance = (AExpressionType)Activator.CreateInstance(falseType);
                result = falseInstance.GetResult(source, sourceConditional.IfFalse);
            }
            return result;
        }

    }
}
