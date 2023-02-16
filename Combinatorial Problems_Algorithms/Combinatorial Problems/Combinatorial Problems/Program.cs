using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace CombinatiorialProblems
{
    public class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int k;

        public static void Main()
        {
            elements = Console.ReadLine().Split(); 
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];
            Combinations(0, 0);
        }

        private static void Combinations(int idx, int startIndex)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                Combinations(idx + 1, i + 1);
            }
        }
    }
}