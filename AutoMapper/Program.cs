using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string str = "123";
            //Type destType = typeof(int);
            //MethodInfo methodInfo = destType.GetMethod("Parse", new Type[] { typeof(string) });
            //object value = methodInfo.Invoke(null, new object[] { str });



            //TDest dest = Mapper.Map<TSource, TDest>(source)
            StudentDAO A = new StudentDAO("B", "A", 32, new List<string>() { "3", "2", "4" });

            var destA = Mapper.Map<StudentDAO, StudentDTO>(A);
            Console.WriteLine($"{destA.Name} || {destA.Class} || {destA.Number}");
            destA.strings.ForEach(x => Console.WriteLine(x));


            //object strings = new List<string>() { "1", "2", "3", "4", "5" };
            //Type destType = typeof(List<int>);

            //// 我要怎麼知道我自己是List?
            //Type sourceType = strings.GetType();
            //bool isEnumerableType = sourceType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            //bool destIsEnumerableType = destType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            //if (isEnumerableType && destIsEnumerableType)
            //{
            //    // 我怎麼知道我自己有多少參數?
            //    var sourceArgs = sourceType.GetGenericArguments();
            //    var destArgs = destType.GetGenericArguments();

            //    //取得空泛型 List<>
            //    var destTypeDefinition = destType.GetGenericTypeDefinition();
            //    // 製作List<int>
            //    var listofIntType = destTypeDefinition.MakeGenericType(destArgs);

            //    var listOfInt = Activator.CreateInstance(listofIntType);

            //    IEnumerable source = (IEnumerable)strings;

            //    IEnumerator enumerator = source.GetEnumerator();

            //    while (enumerator.MoveNext())
            //    {

            //        var item = enumerator.Current;

            //        Type destArg = destArgs[0];
            //        MethodInfo method = destArg.GetMethod("Parse", new Type[] { sourceArgs[0] });

            //        var value = method.Invoke(null, new object[] { item });

            //        IList collection = (IList)listOfInt;
            //        collection.Add(value);

            //    }


            //}








            Console.ReadKey();
        }
    }
}
