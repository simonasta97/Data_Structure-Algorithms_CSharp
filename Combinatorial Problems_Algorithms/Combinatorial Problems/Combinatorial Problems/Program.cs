using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace CombinatiorialProblems
{
    public class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        private static int k;

        public static void Main()
        {
            elements = Console.ReadLine().Split();
            
            
            used = new bool[elements.Length];
            k = int.Parse(Console.ReadLine());
            variations = new string[k];
            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[idx] = elements[i];
                    Variations(idx + 1);
                    used[i] = false;
                }
            }
        }
    }
}