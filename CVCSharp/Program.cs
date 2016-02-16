using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Namespaces.foo.Do());
            Console.WriteLine(Namespaces.bar.Do());

            Pointers.PointersAreNotSafe();

            Pointers.DynamicMemory();

            Foreach.PrintArray();

            Foreach.PrintHalfPyramid(5);
            Foreach.PrintHalfPyramid(10);
        }
    }

    namespace Namespaces
    {
        public class foo
        {
            public static int Do()
            {
                return 2 + 2;
            }
        }

        public class bar
        {
            public static string Do()
            {
                return "Do the dew";
            }
        }
    }

    public static class Pointers
    {
        public static void PointersAreNotSafe()
        {
            int x = 1;
            int y = 2;

            Console.WriteLine("Before swap:");
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);

            unsafe
            {
                Swap(&x, &y);
            }

            Console.WriteLine("After swap:");
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
        }

        unsafe public static void Swap(int* a, int* b)
        {
            int temp = *a;
            *a = *b;
            *b = temp;
        }

        public static void DynamicMemory()
        {
            Console.WriteLine("How many random numbers do you want?");
            string answer = Console.ReadLine();

            int count;
            bool success = int.TryParse(answer, out count);

            if (success)
            {
                int[] numbers = new int[count];
                var rng = new System.Random();

                for (int i = 0; i < count; i++)
                {
                    numbers[i] = rng.Next() % 100;
                }

                Console.WriteLine("Your random numbers");
                foreach(var element in numbers)
                {
                    Console.WriteLine(element);
                }

                // I feel like I'm supposed to do something here...
            }
            else
            {
                Console.WriteLine("No numbers for you then.");
            }
        }
    }

    public static class Foreach
    {
        public static void PrintHalfPyramid(int height)
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    Console.Write('#');
                }

                Console.WriteLine();
            }
        }

        public static void PrintArray()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var element in arr)
            {
                Console.WriteLine(element);
            }
        }
    }
}
