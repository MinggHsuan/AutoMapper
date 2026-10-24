using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class UnaryType : AExpressionType
    {
        public override object GetResult(object source, Expression sourceCallback)
        {
            UnaryExpression sourceUnary = (UnaryExpression)sourceCallback;
            MemberExpression sourceMember = (MemberExpression)sourceUnary.Operand;
            PropertyInfo sourceProp = (PropertyInfo)sourceMember.Member;

            return !(bool)sourceProp.GetValue(source);
        }
    }
}
