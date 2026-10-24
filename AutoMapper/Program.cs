using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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


            //List<StudentDAO> studentDAOs = new List<StudentDAO>()
            //{
            //    new StudentDAO("Leo","1",1,new Package("30")),
            //    new StudentDAO("Xuan","2",2,new Package("30")),
            //    new StudentDAO("Jeff","1",1,new Package("30")),
            //    new StudentDAO("Lisa","2",2,new Package("30")),
            //    new StudentDAO("John","1",2,new Package("30")),
            //    new StudentDAO("Matt","1",2,new Package("30"))
            //};

            //var destA = Mapper.GroupMap<StudentDAO, StudentDTO>(studentDAOs);
            //foreach (var item in destA)
            //{
            //    Console.WriteLine($"{item.Name} || {item.Class} || {item.Number}");
            //}

            //StudentDAO A = new StudentDAO("B", "A", 32, new Dictionary<string, string>() { { "A", "1" }, { "B", "2" } });
            //StudentDAO A = new StudentDAO("5", "1", 5, new Package("30", new List<string> { "3", "2" }
            //, new List<Pencil>()
            //{
            //    new Pencil("綠色",80,"A",new Rule(40,50)),
            //    new Pencil("黃色",60,"D",new Rule(80,90)),
            //    new Pencil("綠色",10,"C",new Rule(100,50)),
            //    new Pencil("綠色",50,"D",new Rule(70,30)),
            //}));

            StudentDAO A = new StudentDAO("5", "1", 5);
            var destA = Mapper.Map<StudentDAO, StudentDTO>(A, config =>
            {
                //config.ForMember(x => int.Parse(x.Name1) + 2 + x.Number1, x => x.Name);
                config.ForMember(x => x.Name1 != "5" ? int.Parse("6") : Add(8, 9), x => x.Name);
                //config.ForMember(x => Add(2, 6) > 5 && x.Number1 > 0, x => x.Name);
                config.ForMember(x => x.Class1, x => x.Class);
                config.ForMember(x => x.Number1, x => x.Number);

            });
            //Console.WriteLine($"{destA.Name} || {destA.Class} || {destA.Number}");


            Console.ReadKey();







            //object strings = new string[] { "1", "2", "3", "4", "5" };
            //Type destType = typeof(int[]);

            //// 我要怎麼知道自己是陣列?
            //Type sourceType = strings.GetType();
            //if (sourceType.IsArray && destType.IsArray)
            //{
            //    Array sourceArray = (Array)strings;
            //    Type sourceElementType = sourceType.GetElementType();
            //    Type destElementType = destType.GetElementType();

            //    Array destArray = Array.CreateInstance(destElementType, sourceArray.Length);
            //    for (int i = 0; i < sourceArray.Length; i++)
            //    {
            //        object sourceElement = sourceArray.GetValue(i);
            //        destArray.SetValue(sourceElement, i);
            //    }
            //}






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





            //var pencils = new List<Pencil>()
            //{
            //     new Pencil("綠色",80, "7cm",new Dictionary<string, Rule>()
            //     {
            //         { "國文字典",new Rule(20,30)},
            //         { "字典",new Rule(40,50)}
            //     }),
            //     new Pencil("黃色", 60,"8cm",new Dictionary<string, Rule>()
            //     {
            //         { "數學字典",new Rule(60,70)},
            //         { "字典",new Rule(80,90)}
            //     }),
            //     new Pencil("綠色", 10,"9cm",new Dictionary<string, Rule>()
            //     {
            //         { "數學字典",new Rule(100,50)},
            //         { "字典",new Rule(50,60)}
            //     }),
            //     new Pencil("綠色",50 ,"10cm",new Dictionary<string, Rule>()
            //     {
            //         { "數學字典",new Rule(50,10)},
            //         { "字典",new Rule(70,30)}
            //     })
            //};
            //var pencils = new List<Pencil>()
            //{
            //     new Pencil("綠色",80,"A",new Rule(40,50)),
            //     new Pencil("黃色",60,"D",new Rule(80,90)),
            //     new Pencil("綠色",10,"C",new Rule(100,50)),
            //     new Pencil("綠色",50,"D",new Rule(70,30)),
            //};

            //var pecilOrders = pencils.QuickSort(x => x.keyValues["字典"]);
            //var pecilOrders = pencils.QuickSort(x => x.rule);
            //HW:
            // 1. 思考如何使用內建CompareTo 將使用者指定的任意屬性都能進行比較
            // 2. 即使使用者操作的是屬性物件 也依然可以做比較


            //Test(new List<Pencil>(), x => 12.5);

            //Console.ReadKey();
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }

        //private static void Test<T>(List<Pencil> datas, Expression<Func<Pencil, T>> expression)
        //{

        //    ConstantExpression constantExpression = expression.Body as ConstantExpression;

        //    object obj = constantExpression.Value;
        //}
        //public static List<Pencil> QuickSort(this List<Pencil> datas, Expression<Func<Pencil, int>> expression)
        //{
        //    MemberExpression memberExpression = expression.Body as MemberExpression;
        //    PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;

        //    object obj = propertyInfo.GetValue(datas[0]);

        //    Func<Pencil, int> func = expression.Compile();
        //    int t = func.Invoke(datas[0]);
        //}
    }
}
