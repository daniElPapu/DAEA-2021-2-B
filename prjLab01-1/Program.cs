using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLab01_1
{
    class Program
    {
        static int Suma(int a, int b) {
            return a + b;
        }
        static void Raiz(int a, int b)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raíz cuadrada de {0} es: {1}", i, Math.Sqrt(i));
            }

        }
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y Funciones";
            Console.WriteLine("Menú 1.Suma 2.Resta");
            string opcion = Console.ReadLine();
            if (opcion == "1"){
                Console.WriteLine("Ingrese le primer número");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese le segundo número");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));
            }
            else
            {
                Console.WriteLine("Ingrese le primer número");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese le segundo número");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("La resta de {0} y {1} es {2}", a, b, Suma(a, b));
            }
            Console.ReadKey();

        }
    }
}
