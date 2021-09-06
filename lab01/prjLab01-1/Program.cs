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
        static int Resta(int a, int b) {
            return a - b;
        }
        static int Producto(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            if (b != 0)
                return a / b;
            else
            {
                Console.WriteLine("No se pudo realizar la division por se inoperable( division entre 0)");
                return 0;
            }
        }
        static void Primos10() {
            int contador = 0;
            // El primer número primo es 2
            int numero = 2;
            Console.WriteLine("Numeros Primos");
            while (contador < 10) {
                bool is_primo = true;
                for (int i = 2; i <numero;i++) {
                    if (numero % i == 0) {
                        is_primo = false;
                        break;
                    }
                }
                if (is_primo) {
                    Console.WriteLine("{0}. {1}",(contador+1),numero);
                    contador++;
                }
            }
        }
        static int CtoF(int a) {
            int r = a*9/5+32;
            return r;
        }
        static int FtoC(int a)
        {
            int r = 5*(a- 32)/9;
            return r;
        }
        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raíz cuadrada de {0} es: {1}", i, Math.Sqrt(i));
            }

        }
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos números");
                Console.WriteLine("[2] Resta de dos números");
                Console.WriteLine("[3] Producto de dos números");
                Console.WriteLine("[4] División de dos números");
                Console.WriteLine("[5] Imprimir la raíz cuadrada de los 10 primeros números enteros");
                Console.WriteLine("[6] Imprimir los 10 primeros números primos");
                Console.WriteLine("[7] Conversión de temperatura Celcius a Farenheit");
                Console.WriteLine("[8] Conversión de temperatura Farenheit a Celcius");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opción y presione ENTER");
                opcion = Console.ReadLine();
                int a, b;
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La resta de {0} y {1} es {2}", a, b, Resta(a, b));

                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El producto de {0} y {1} es {2}", a, b, Producto(a, b));
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Division de {0} y {1} es {2}", a, b, Division(a, b));
                        break;
                    case "5":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        break;
                    case "6":
                        Console.WriteLine("Calculando...");
                        Primos10();
                        break;
                    case "7":
                        Console.WriteLine("Ingrese el valor en celcius a transformar");
                        a = Convert.ToInt32(Console.ReadLine());
                        b = CtoF(a);
                        Console.WriteLine("El valor de {0} Celcius en Farenheit es {1}", a, b);
                        break;
                    case "8":
                        Console.WriteLine("Ingrese el valor en Farenheit a transformar");
                        a = Convert.ToInt32(Console.ReadLine());
                        b = FtoC(a);
                        Console.WriteLine("El valor de {0} Farenheit en Celsius es {1}",a,b);
                        break;
                }
                Console.ReadKey();
            } while (!opcion.Equals("0"));


        }
    }
}
