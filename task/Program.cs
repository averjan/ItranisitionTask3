using System;
using System.Security.Cryptography;
using System.Linq;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args.Length < 3) || (args.Length % 2 == 0))
            {
                Console.WriteLine("Number of arguments must be more than 2 and odd. Example: 1 2 3 4 5");
                return;
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Arguments must be unic. Example: a b c");
                return;
            }

            var rng = RandomNumberGenerator.Create();
            var key = new byte[16];
            rng.GetBytes(key);
            var compStep = args[RandomNumberGenerator.GetInt32(0, args.Length)];
            var hmac = new HMACSHA256(key);
            var userHMAC = hmac.ComputeHash(compStep.Select(c => (byte)c).ToArray());
            Console.WriteLine("HMAC:");
            Console.WriteLine(string.Join("", userHMAC
                                    .Select(c => c.ToString("X"))
                                    .ToArray()));
            Battle.Game(args, compStep);
            Console.WriteLine(string.Join("", key.Select(c => c.ToString("X"))
                                                .ToArray()));
        }
    }
}
