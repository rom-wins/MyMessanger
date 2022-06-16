using MyMessanger;
using Newtonsoft.Json;
using System;

namespace MyApp
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        public static void GetNewMessages()
        {
            Message msg = API.GetMessage(MessageID);
            while(msg != null)
            {
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }

        static void Main(string[] args)
        {
            //Message msg = new Message("Роман", "Privet", DateTime.Now);
            //string output = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(output);
            //Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            //Console.WriteLine(deserializedMsg);
            //{ "UserName":"Роман","MessageText":"Privet","TimeStamp":"2022-06-14T16:29:04.9158952+08:00"}
            //RusAl<Privet>: 14.06.2022 16:29:04

            MessageID = 1;
            Console.Write("Введите ваше имя: ");
            //UserName = "Роман";
            UserName = Console.ReadLine();
            string MessageText = "";
            while (MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }
            }
        }


    }
}