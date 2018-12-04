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
        public class Boo : IDisposable
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
            public void Dispose()
            {
                Console.WriteLine("[Boo]destroy");
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
                dynamic obj1 = Activator.CreateInstance(tp, 1,2,"banana");
                //obj1.DoingSomething(10, 30, "apple");

                dic.TryGetValue("Boo", out tp);
                // using (dynamic obj2 = Activator.CreateInstance(tp, 5, 6, "apple")) {}
                dynamic obj2 = Activator.CreateInstance(tp, 5, 6, "apple");
                obj2.Dispose();
                Console.WriteLine("really really finished.");
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
