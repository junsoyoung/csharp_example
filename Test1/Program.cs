using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using System.Runtime.Serialization.Formatters.Binary;

namespace Test1
{
    [Serializable]
    struct DATA
    {
        public int var1;
        public float var2;
        [NonSerialized]
        public string var3;
    }
    class Program
    {
        public void Serialize()
        {

        }
        public object Desialize()
        {
            object obj = new object();
            return obj;
        }
        
        static void Main(string[] args)
        {
            DATA[] data = new DATA[2];
            data[0].var1 = 0;
            data[0].var2 = 1.10f;
            data[0].var3 = "first data";
            data[1].var1 = 1;
            data[1].var2 = 2.20f;
            data[1].var3 = "second data";

            DATA[] resultData;

            using (System.IO.FileStream fs = new System.IO.FileStream("abc.txt", System.IO.FileMode.Create) )
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, data);
                // resultData = (DATA[])bf.Deserialize(fs);
            }


            using (System.IO.FileStream fs = new System.IO.FileStream("abc.txt", System.IO.FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                resultData = (DATA[])bf.Deserialize(fs);
            }


            //Console.WriteLine("ABC");
            //List<int> list = new List<int>();
            //list.Add(0);
            //list.Add(10);

            //Console.WriteLine(list[0]);
            //Console.WriteLine(list[1]);

            //string szData = "C언어:90 C#언어:100 컴퓨터구조:70";
            //string[] szSept = szData.Split(new char[] { ':', ' ' });
            //List<string> listSept = new List<string>(szSept);
            //foreach (string data in listSept)
            //{
            //    Console.WriteLine(data);
            //}
            Console.ReadKey();

        }
    }
}
