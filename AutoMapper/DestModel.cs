using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class DestModel
    {
        public ExpressionType destType { get; set; }
        public object sourceValue { get; set; }
        public System.Linq.Expressions.ExpressionType unaryType { get; set; }
        public DestModel(ExpressionType type, object sourceValue)
        {
            this.destType = type;
            this.sourceValue = sourceValue;
        }
        public DestModel(ExpressionType type, object sourceValue, System.Linq.Expressions.ExpressionType unaryType)
        {
            this.destType = type;
            this.sourceValue = sourceValue;
            this.unaryType = unaryType;
        }
    }
}
