using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal static class Extend
    {
        public static ValueEnumType FindType(this Type destType)
        {
            if (destType.IsEnum)
            {
                return ValueEnumType.EnumType;
            }
            else if (destType.IsArray)
            {
                return ValueEnumType.ArrayType;
            }
            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
            {
                return ValueEnumType.DictionaryType;
            }
            else if (destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                return ValueEnumType.ListType;
            }
            else if (destType.IsClass && destType != typeof(string))
            {
                return ValueEnumType.ClassType;
            }
            else
            {
                return ValueEnumType.BasicType;
            }
        }

        public static ExpressionType FindExpType(this Expression expression)
        {
            if (expression is ConstantExpression)
            {
                return ExpressionType.ConstantType;
            }
            else if (expression is MemberExpression)
            {
                return ExpressionType.MemberType;
            }
            else if (expression is MethodCallExpression)
            {
                return ExpressionType.MethodCallType;
            }
            else if (expression is UnaryExpression)
            {
                return ExpressionType.UnaryType;
            }
            else if (expression is BinaryExpression)
            {
                return ExpressionType.BinaryType;
            }
            else if (expression is ParameterExpression)
            {
                return ExpressionType.ParameterType;
            }
            else if (expression is NewExpression)
            {
                return ExpressionType.NewExpType;
            }
            else if (expression is ConditionalExpression)
            {
                return ExpressionType.ConditionalType;
            }
            else
            {
                return ExpressionType.NULL;
            }
        }
        public static List<T> QuickSort<T, TProp>(this List<T> datas, Expression<Func<T, TProp>> callback)
        {
            QuickBoxNumber(datas, 0, datas.Count - 1, callback);
            return datas;
        }

        public static void QuickBoxNumber<T, TProp>(List<T> list, int left, int right, Expression<Func<T, TProp>> callback)
        {
            MemberExpression memberExpression = callback.Body as MemberExpression;
            PropertyInfo property = (PropertyInfo)memberExpression.Member;
            object leftValue = property.GetValue(list[left]);
            object rightValue = property.GetValue(list[right]);
            MethodInfo method = leftValue.GetType().GetMethod("CompareTo", new Type[] { property.PropertyType });

            int start = left;
            int end = right;
            object box = leftValue;
            while (start != end)
            {
                if (int.Parse(method.Invoke(leftValue, new object[] { rightValue }).ToString()) == 0)
                {
                    end--;
                    rightValue = property.GetValue(list[end]);
                }
                while (int.Parse(method.Invoke(leftValue, new object[] { rightValue }).ToString()) > 0)
                {
                    end--;
                    rightValue = property.GetValue(list[end]);
                }
                if (int.Parse(method.Invoke(leftValue, new object[] { rightValue }).ToString()) < 0)
                {
                    (list[end], list[start]) = (list[start], list[end]);
                    leftValue = property.GetValue(list[start]);
                    rightValue = property.GetValue(list[end]);
                }
                while (int.Parse(method.Invoke(box, new object[] { leftValue }).ToString()) < 0)
                {
                    start++;
                    leftValue = property.GetValue(list[start]);
                }
                if (int.Parse(method.Invoke(box, new object[] { leftValue }).ToString()) > 0)
                {
                    (list[start], list[end]) = (list[end], list[start]);
                    leftValue = property.GetValue(list[start]);
                    rightValue = property.GetValue(list[end]);
                }
            }
            if (start != left)
            {
                QuickBoxNumber(list, left, start - 1, callback);
            }
            if (right != end)
            {
                QuickBoxNumber(list, end + 1, right, callback);
            }



            //while (start != end)
            //{
            //    while (rightValue < leftValue)
            //    {
            //        end--;
            //        rightValue = int.Parse(property.GetValue(list[end]).ToString());
            //    }
            //    if (rightValue > leftValue)
            //    {
            //        (list[end], list[start]) = (list[start], list[end]);
            //        leftValue = int.Parse(property.GetValue(list[start]).ToString());
            //        rightValue = int.Parse(property.GetValue(list[end]).ToString());
            //    }
            //    while (box < leftValue)
            //    {
            //        start++;
            //        leftValue = int.Parse(property.GetValue(list[start]).ToString());
            //    }
            //    if (box > leftValue)
            //    {
            //        (list[start], list[end]) = (list[end], list[start]);
            //        leftValue = int.Parse(property.GetValue(list[start]).ToString());
            //        rightValue = int.Parse(property.GetValue(list[end]).ToString());
            //    }
            //}
            //if (start != left)
            //{
            //    QuickBoxNumber(list, left, start - 1, callback);
            //}
            //if (right != end)
            //{
            //    QuickBoxNumber(list, end + 1, right, callback);
            //}
        }
    }
}
