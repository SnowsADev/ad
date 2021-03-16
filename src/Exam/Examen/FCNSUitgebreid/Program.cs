using System;

namespace AD
{
    class Program
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //
        // In de opgave staat dat hier de method
        //    FirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        // gemaakt moet worden.
        // Dit is een foutje. Implementeer in plaats daarvan de method
        //    IFirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        // in FCNSUitgebreidBuilder.cs
        // 
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        static void Main(string[] args)
        {
            // Part a
            IFirstChildNextSibling<int> tree = DSBuilder.CreateFirstChildNextSibling_Practicum();

            // Part b

            for (int i = 1; i <= 8; i++)
            {
                IFCNSNode<int> parent = tree.FindParent(i);
                Console.WriteLine($"parent of {i}: {(parent != null ? parent.ToString() : "null" )}");
            }

            // Part c
            
        }

        
    }
}