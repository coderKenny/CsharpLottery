using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    static class Apuluokka
    {
        public static void Pause()
        {
            Console.Write("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        public static void InsertLineSepatator()
        {
            Console.Write("\n----------------------------\n");

        }

        public static void InsertWideLineSepatator()
        {
            Console.Write("\n\n----------------------------\n\n");

        }

        public static void InsertLines(int amount)
        {
            for (int i = 0; i < amount; i++)
                Console.WriteLine();
        }

        public static void WL()
        {
            Console.WriteLine();
        }
    }
}
