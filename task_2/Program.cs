//Завдання 2
//Створіть додаток для виконання арифметичних операцій. Підтримувані операції:
// ■ Додавання двох чисел;
// ■ Віднімання двох чисел;
// ■ Множення двох чисел.
//Код програми обов’язково має використати механізм делегатів.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public delegate double CalcDelegate(double x, double y);
    public class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mult(double x, double y)
        {
            return x * y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Dictionary<char, CalcDelegate> actions = new Dictionary<char, CalcDelegate>();
            actions['+'] = calc.Add;
            actions['-'] = calc.Sub;
            actions['*'] = calc.Mult;

            Console.Write("Enter an expression: ");
            string expression = Console.ReadLine();

            char sign = ' ';

            // определения знака арифметического действия
            foreach (char item in expression)
            {
                if (item == '+' || item == '-' || item == '*')
                {
                    sign = item;
                    break;
                }
            }

            try
            {
                if (sign != ' ')
                {
                    string[] numbers = expression.Split(sign);

                    Console.WriteLine($"Result: {actions[sign](double.Parse(numbers[0]), double.Parse(numbers[1]))}");
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
