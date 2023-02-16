using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace CombinatiorialProblems
{
    public class Program
    {
        private static string[] elements;

        public static void Main()
        {
            elements = new[] {"A","B","C" };
            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx>= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}