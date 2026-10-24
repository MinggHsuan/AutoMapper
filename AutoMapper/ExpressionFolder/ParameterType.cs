using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class ParameterType : AExpressionType
    {
        public override object GetResult(object source, Expression sourceCallback)
        {
            return source;
        }
    }
}
