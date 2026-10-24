using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class ConstantType : AExpressionType
    {

        public override object GetResult(object source, Expression sourceCallback)
        {
            ConstantExpression sourceConstant = (ConstantExpression)sourceCallback;
            return sourceConstant.Value;
        }
    }
}
