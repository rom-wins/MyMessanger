using MyMessanger;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message();
            Console.WriteLine("Начало проекта!");
            Console.WriteLine(msg.ToString());
        }
    }
}