using System;
using System.Linq;

namespace task
{
    static class Battle
    {
        static int GetUserStep(string[] items)
        {
            int inp;
            do
            {
                Console.WriteLine("Availble moves");
                for (var i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {items[i]}");
                }

                Console.WriteLine("0 - exit");
                Console.Write("Enter your move: ");
            }
            while ((!int.TryParse(Console.ReadLine(), out inp))
                    || (inp < 0) || (inp > items.Length));
            return inp;
        }
        public static void Game(string[] items, string compStep)
        {
            int mid, shift, indexCompStep, indexUserStep;
            indexUserStep = GetUserStep(items);
            if (indexUserStep == 0)
            {
                return;
            }

            Console.WriteLine($"Your move: {items[indexUserStep - 1]}");
            Console.WriteLine($"Computer move: {compStep}");
            mid = items.Length / 2;
            shift = indexUserStep - (mid + 1);
            if (shift < 0)
            {
                shift += items.Length;
            }

            items = items.Skip(shift).Concat(items.Take(shift)).ToArray();
            indexCompStep = Array.IndexOf(items, compStep);
            if (indexCompStep < mid)
            {
                Console.WriteLine("You win!");
            }
            else if (indexCompStep == mid)
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }

    }
}
