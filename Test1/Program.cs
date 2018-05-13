using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ABC");
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(10);

            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.ReadKey();

        }
    }
}
