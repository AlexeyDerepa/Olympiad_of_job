using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace _003_Sum_factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Input();

            BigInteger factorial = Factorial(number);

            Out(number,factorial);

            Console.Read();
        }

        private static void Out(int number,BigInteger factorial)
        {
            Console.WriteLine(number +"! = "+factorial);
            Console.WriteLine("Sum = " + Sum(factorial));
        }

        private static int Input()
        {
            bool flag = true;
            int number;
            do{
                Console.Clear();
                Console.WriteLine("Enter number > 0");
                Console.Write("N = ");
                int.TryParse(Console.ReadLine(),out number);
                if (number<=0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }while(flag);
            return number;
        }
        
        static BigInteger Sum(BigInteger number)
        {
            string numberToString = number.ToString();
            BigInteger result = 0;
            foreach (var item in numberToString)
                result += BigInteger.Parse(item.ToString());

            return result;
        }
        static BigInteger Factorial(int number)
        {
            BigInteger result = 1;
            for (int i = number; i > 0; i--)
                result *= i;

            return result;
        }
    }
}
