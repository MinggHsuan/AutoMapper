using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class MemberType : AExpressionType
    {



        public override object GetResult(object source, Expression sourceCallback)
        {
            MemberExpression sourceMember = (MemberExpression)sourceCallback;
            PropertyInfo prop = (PropertyInfo)sourceMember.Member;
            return prop.GetValue(source);
        }
    }
}
