using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionFolder
{
    internal class BinaryType : AExpressionType
    {
        public override object GetResult(object source, Expression sourceCallback)
        {
            BinaryExpression sourceBinary = (BinaryExpression)sourceCallback;

            ExpressionType LeftExpressionType = sourceBinary.Left.FindExpType();
            Type leftType = Type.GetType($"AutoMapper.ExpressionFolder.{LeftExpressionType}");
            AExpressionType leftInstance = (AExpressionType)Activator.CreateInstance(leftType);
            object left = leftInstance.GetResult(source, sourceBinary.Left);

            ExpressionType RightExpressionType = sourceBinary.Right.FindExpType();
            Type rightType = Type.GetType($"AutoMapper.ExpressionFolder.{RightExpressionType}");
            AExpressionType rightInstance = (AExpressionType)Activator.CreateInstance(rightType);
            object right = rightInstance.GetResult(source, sourceBinary.Right);

            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.Add)
            {
                return (int)left + (int)right;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.Subtract)
            {
                return (int)left - (int)right;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.Multiply)
            {
                return (int)left * (int)right;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.Divide)
            {
                return (int)left / (int)right;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.GreaterThan)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) == 1 ? true : false;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.GreaterThanOrEqual)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) == -1 ? false : true;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.LessThan)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) == -1 ? true : false;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.LessThanOrEqual)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) == 1 ? false : true;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.Equal)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) == 0 ? true : false;
            }
            if (sourceBinary.NodeType == System.Linq.Expressions.ExpressionType.NotEqual)
            {
                IComparable comparable = (IComparable)left;
                return comparable.CompareTo(right) != 0 ? true : false;
            }
            if (left is bool isLeft && right is bool isRight)
            {
                return isLeft && isRight;
            }
            return null;
        }
    }
}
