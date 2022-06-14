using MyMessanger;
using Newtonsoft.Json;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("RusAl", "Privet", DateTime.Now);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
            //{ "UserName":"RusAl","MessageText":"Privet","TimeStamp":"2022-06-14T16:29:04.9158952+08:00"}
            //RusAl<Privet>: 14.06.2022 16:29:04
        }
    }
}