using System;
using System.Collections.Generic;
using System.Reflection;

//[assembly: AssemblyVersion("1.0.2000.0")]
namespace DynamicInst
{
    class Program
    {
        public class Foo
        {
            public int iData;
            public int iData2;
            public string szData;
            public Foo(int a, int b, string c)
            {
                iData = a;
                iData2 = b;
                szData = c;
                Console.WriteLine("[Foo]" + iData.ToString() + " " + iData2.ToString() + " " + szData);
            }
        }
        public class Boo
        {
            public int iData;
            public int iData2;
            public string szData;
            public Boo(int a, int b, string c)
            {
                iData = a;
                iData2 = b;
                szData = c;
                Console.WriteLine("[Boo]" + iData.ToString() + " " + iData2.ToString() + " " + szData);
            }
        }
        static Dictionary<string, Type> dic;
        static void Main(string[] args)
        {
            try
            {
                dic = new Dictionary<string, Type>();
                Type tp;
                dic.Add("Foo", typeof(Foo));
                dic.Add("Boo", typeof(Boo));

                dic.TryGetValue("Foo", out tp);
                dynamic obj1 = Activator.CreateInstance(tp, null);
                //obj1.DoingSomething(10, 30, "apple");

                dic.TryGetValue("Boo", out tp);
                dynamic obj2 = Activator.CreateInstance(tp, null);
                //obj2.DoingSomething(1, 3, "banana");
                

            }
            catch(Exception e)
            {
                string szMsg = e.Message.ToString();
                Console.WriteLine(szMsg);
            }
            Console.ReadKey();
            
        }
    }
}
