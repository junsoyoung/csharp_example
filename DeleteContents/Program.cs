using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeleteContents
{
    class Program
    {
        static void Main(string[] args)
        {
            string szFileName = @"E:\006_JKI\115200_1000th_Recipe_0815.jrc";
            string ReadData = System.IO.File.ReadAllText (szFileName);
            string szDeleteContents = "ParamInfo";
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(ReadData);
            int iCnt = 0;
            Dictionary<string, object> dic_new = new Dictionary<string, object>();
            foreach(KeyValuePair<string, object> sy in dic)
            {
                //Console.WriteLine(sy.Key + ": " + sy.Value);
                string szValue = sy.Value.ToString();
                Dictionary<string, object> dic2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(szValue);
                Dictionary<string, object> dic2_new = new Dictionary<string, object>();

                foreach (KeyValuePair<string, object> sy2 in dic2)
                {
                    //Console.WriteLine(sy2.Key + ": " + sy2.Value);
                    if( sy2.Key == szDeleteContents)
                    {
                        dic2.Remove(szDeleteContents);
                        break;
                    }
                    dic2_new[sy2.Key] = sy2.Value ;
                }
                dic_new[sy.Key] = dic2_new ;
            }


            string szNewFileName = @"E:\006_JKI\1.jrc";
            string szNewContents = JsonConvert.SerializeObject(dic_new, Formatting.Indented);
            System.IO.File.WriteAllText(szNewFileName, szNewContents);
            Console.ReadKey();          

        }
    }
}
