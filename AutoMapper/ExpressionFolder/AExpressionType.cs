using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal abstract class AExpressionType
    {
        public abstract object GetResult(object source, Expression sourceCallback);

    }
}
