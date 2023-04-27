//Завдання 3
//Створіть додатки для виконання арифметичних операцій. Підтримувані операції:
// ■ Перевірка числа на парність;
// ■ Перевірка числа на непарність;
// ■ Перевірка на просте число;
// ■ Перевірка на число Фібоначчі.
//Обов’язково використовуйте делегат типу Predicate.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    delegate bool Predicate<in T>(T value);

    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<uint>[] numberChecking = {IsEven, IsOdd, IsNaturalNumber};
            uint number;

            Console.Write(" Введите число: ");
            number = UInt32.Parse(Console.ReadLine());

            Console.WriteLine(" Проверить на:");
            Console.WriteLine(" 1 - Четность\n 2 - Не четность\n 3 - Простое число\n 4 - Число Фибоначчи");
            Console.Write(" > ");
            uint index = UInt32.Parse(Console.ReadLine());

            if (index >= 1 && index <= 4)
            {
                bool flag = numberChecking[index - 1](number);

                Console.Write($"Число: {number} ");

                switch (index)
                {
                    case 1:
                        if (flag)
                        {
                            Console.WriteLine("четное");
                        }
                        else
                        {
                            Console.WriteLine("не четное");
                        }
                        break;
                    case 2:
                        if (flag)
                        {
                            Console.WriteLine("не четное");
                        }
                        else
                        {
                            Console.WriteLine("четное");
                        }
                        break;
                    case 3:
                        if (flag)
                        {
                            Console.WriteLine("натуральное число");
                        }
                        else
                        {
                            Console.WriteLine("не натуральное число");
                        }
                        break;
                }
            }
        }

        public static bool IsEven(uint number)
        {
            return (number % 2 == 0) ? true : false;
        }
        public static bool IsOdd(uint number)
        {
            return (number % 2 != 0) ? true : false;
        }
        public static bool IsNaturalNumber(uint number)
        {
            if (number == 1)
            {
                return false;
            }

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
