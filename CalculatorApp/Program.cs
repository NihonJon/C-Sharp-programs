using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine(" ");
            Console.WriteLine("Input the first number: ");
            var firstAsText = Console.ReadLine();
            var number1 = int.Parse(firstAsText);

            Console.WriteLine("Input the second number: ");
            var secondAsText = Console.ReadLine();
            var number2 = int.Parse(secondAsText);

            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd");
            Console.WriteLine("[S]ubtract");
            Console.WriteLine("[M]ultiply");
            Console.WriteLine("[D]ivide");
            var choice = Console.ReadLine();

            if(EqualsCaseInsenitive(choice, "A"))
            {
                var sum = number1 + number2;
                PrintFinalEquation(number1, number2, sum, "+");
            }
            else if (EqualsCaseInsenitive(choice, "S"))
            {
                var difference = number1 - number2;
                PrintFinalEquation(number1, number2, difference, "-");
            }
            else if (EqualsCaseInsenitive(choice, "M"))
            {
                var multiplied = number1 * number2;
                PrintFinalEquation(number1, number2, multiplied, "*");
            }
            else if (EqualsCaseInsenitive(choice, "D"))
            {
                double divided = Convert.ToDouble(number1) / Convert.ToDouble(number2);
                Console.WriteLine(number1 + " / " + number2 + " = " + divided);
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();

            void PrintFinalEquation(
                int number1, int number2, int result, string @operator)
            {
                Console.WriteLine(
                    number1 + " " + @operator + " " + number2 + " = " + result);
            }

            bool EqualsCaseInsenitive(string left,  string right)
            {
                return left.ToUpper() == right.ToUpper();
            }
        }
    }
}
