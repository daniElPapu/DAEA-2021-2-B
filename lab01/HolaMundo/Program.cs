using System;

namespace HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Como te llamas?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Hola"+ nombre);
        }
    }
}
