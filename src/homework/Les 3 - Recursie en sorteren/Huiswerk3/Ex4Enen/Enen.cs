﻿namespace AD
{
    public class Opgave4
    {
        public static int Enen(int n)
        {
            if (n <= 1)
                return n;

            return ( n % 2 ) + Enen( n / 2 );
        }

        public static void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("Enen({0,4}) = {1,2}", i, Enen(i));
            }
            System.Console.WriteLine("Enen(1024) = {0,2}", Enen(1024));
            System.Console.WriteLine();
        }
    }
}
