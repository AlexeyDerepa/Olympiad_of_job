using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_brace
{
    class Program
    {
        static List<string> list = new List<string>();
        public static void Main(string[] args)
        {
            int number = Input();

            string str = new string('(', number) + new string(')', number);
            char[] myArray = str.ToCharArray();
            int begin = 0, end = str.Length - 1;

            permutation(ref begin, ref end, ref myArray);

            Out(number);

            Console.ReadLine();
        }
        private static int Input()
        {
            int number = 0;
            do
            {
                Console.Clear();
                Console.Write("Enter a number of braces\nN = ");
                int.TryParse(Console.ReadLine(), out number);
            } while (number == 0);
            return number;
        }

        private static void Out(int number)
        {
            list = list.Where(x => CheckIn(x) == true).ToList();

            Console.WriteLine(string.Format("for {0} braces exist {1} permutations:", number, list.Count));

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(i + 1 + " " + list[i]);
        }

        public static void Swap(ref char a, ref char b) //to change the values of the elements
        {
            char d = a;
            a = b;
            b = d;
        }
        public static void permutation(ref int begin, ref int end, ref char[] myArray) //recursive function
        {
            string temp = "";
            if (begin == end)
            {
                temp = new string(myArray.ToArray());   //char array to string
                if (!list.Contains(temp))
                    list.Add(temp);                     //add item
            }
            else
            {
                for (int i = begin + 1; i <= end; i++)
                {
                    Swap(ref myArray[i], ref myArray[begin + 1]);
                    begin++;
                    permutation(ref begin, ref end, ref myArray);  //permutation
                    begin--;
                    Swap(ref myArray[i], ref myArray[begin + 1]);
                }
            }
        }
        static bool CheckIn(string str)
        {
            int countLeft = 0;
            int countRight = 0;
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == ')')
                    countRight++;
                else if (str[i] == '(')
                    countLeft++;

                if (countRight > countLeft)
                    return false;
            }

            if (countLeft != countRight)
                return false;

            return true;
        }

    }
}
