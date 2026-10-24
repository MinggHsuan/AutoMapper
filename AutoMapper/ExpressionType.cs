using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal enum ExpressionType
    {
        ConstantType,
        MemberType,
        ParameterType,
        MethodCallType,
        LambdaType,
        BinaryType,
        UnaryType,
        NewExpType,
        ConditionalType,
        NULL
    }
}
