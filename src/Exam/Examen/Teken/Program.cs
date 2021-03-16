using System;

namespace AD
{
    public class PracticumTeken
    {
        public static string Teken(int n)
        {
            if (n > 0)
                return $"{Teken(n-1)}{n}{Teken(n - 1)}";
            

            return "0";
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"Teken({i})={Teken(i)}");
            Console.WriteLine(Teken(9));

        }
    }
}
