using System;
namespace Ceasar.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 33; i < 128; i++)
            {
                Console.WriteLine("{0}: {1}",i,(char)i);
            }
            Console.ReadLine();
        }
    }
}
