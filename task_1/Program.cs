//Завдання 1
//Створіть додаток, який відображає текстове повідомлення. Використовуйте механізми делегатів. Делегат має 
//повертати void та приймати один параметр типу string (текст повідомлення). Для тестування додатка створіть 
//різні методи виклику через делегат.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public delegate void GetMessage(string str);
    public class Message
    {
        public static void PrintMessageStatic(string str)
        {
            Console.WriteLine(str);
        }
        public void PrintMessage(string str)
        {
            Console.WriteLine(str);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message();

            GetMessage getStringMsg = new GetMessage(Message.PrintMessageStatic);

            getStringMsg.Invoke("message 1");
            getStringMsg("message 2");

            getStringMsg = new GetMessage(message.PrintMessage);
            getStringMsg.Invoke("message 3");
            getStringMsg("message 4");

            getStringMsg = message.PrintMessage;
            getStringMsg.Invoke("message 5");
            getStringMsg("message 6");

            getStringMsg = Message.PrintMessageStatic;
            getStringMsg("message 7");
        }
    }
}
