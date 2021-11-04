 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;



namespace Lab11_A
{
    class Program
    {
        static void Main(string[] args)
        {
            decimoSexto();
        }
        static void primero() {
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<string> productNames = from p in products select p.Name;

                Console.WriteLine("Productos: ");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
            }
        }
        static void segundo()
        {
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<string> productNames = products.Select(p=>p.Name);

                Console.WriteLine("Productos: ");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
            }
        }
        static void tercero()
        {
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<Product> productQuery = from p in products select p;
                IQueryable<Product> largeProducts = productQuery.Where(p => p.Size == "L");

                Console.WriteLine("Productos de tamaño 'L': ");
                foreach (var product in largeProducts)
                {
                    Console.WriteLine(product.Name);
                }
                Console.ReadKey();
            }
        }
        static void cuarto()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productsQuery = from product in context.Product select product;

                Console.WriteLine("Productos: ");
                foreach (var prod in productsQuery)
                {
                    Console.WriteLine(prod.Name);
                }
                Console.ReadKey();
            }
        }
        static void quinto()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product select 
                            new {   ProductId = product.ProductID,
                                    ProductName = product.Name
                            };

                Console.WriteLine("Información de los productos: ");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product Id: {0} Product Name: {1}",productInfo.ProductId,productInfo.ProductName);
                }
                Console.ReadKey();
            }
        }
        static void octavo()
        {
            int orderQtyMin = 2;
            int orderQtyMax = 6; 
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from order in context.SalesOrderDetail
                            where order.OrderQty > orderQtyMin
                                && order.OrderQty < orderQtyMax
                            select 
                            new {   SalesOrderId = order.SalesOrderID,
                                    OrderQty = order.OrderQty
                            };

                Console.WriteLine("Pedidos de entre 2 a 6 de cantidad: ");
                foreach (var order in query)
                {
                    Console.WriteLine("Order Id: {0} Order Quantity: {1}",
                        order.SalesOrderId,order.OrderQty);
                }
                Console.ReadKey();
            }
        }
        static void noveno()
        {
            string color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            where product.Color == color
                            select
                            new
                            {
                                Name = product.Name,
                                ProductNumber = product.ProductNumber,
                                ListPrice = product.ListPrice
                            };

                Console.WriteLine("Productos de color rojo: ");
                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}",product.Name);
                    Console.WriteLine("Product Number: {0}", product.ProductNumber);
                    Console.WriteLine("List Price: {0}", product.ListPrice);
                    Console.WriteLine("");


                }
                Console.ReadKey();
            }
        }
        static void decimo() 
        { 
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                int?[] productModelsIds = { 19,26,118};
                var products = from p in context.Product
                            where productModelsIds.Contains(p.ProductModelID)
                            select p;

                foreach (var product in products)
                {
                    Console.WriteLine("{0} : {1}",
                        product.ProductModelID, product.ProductID);
                }
                Console.ReadKey();
            }
        }
        static void duodecimo()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<Decimal> sortedPrices = from p in context.Product
                                                   orderby p.ListPrice descending
                                                   select p.ListPrice;
                Console.WriteLine("Lista de precios desde el más alto al más bajo: ");
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
                Console.ReadKey();
            }
        }
        
        static void decimoCuarto()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                               group product by product.Style into g 
                               select new { 
                                   Style = g.Key,
                                   AverageListPrice = g.Average(product => product.ListPrice)
                               };
                Console.WriteLine("Lista de estilos de productos y su precio promedio: ");
                foreach (var product in query)
                {
                    Console.WriteLine("Estilo: {0} Precio Promedio:{1}",
                        product.Style,product.AverageListPrice);
                }
                Console.ReadKey();
            }
        }
        static void decimoQuinto()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                            group product by product.Color into g
                            select new
                            {
                                Color = g.Key,
                                ProductCount = g.Count()
                            };
                Console.WriteLine("Lista de colores de productos y su cantidad en productos: ");
                foreach (var product in query)
                {
                    Console.WriteLine("Color: {0}\t  Cantidad:{1}",
                        product.Color, product.ProductCount);
                }
                Console.ReadKey();
            }
        }
        static void decimoSexto()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var orders = context.SalesOrderHeader;
                var query = from order in orders
                            group order by order.SalesPersonID into g
                            select new
                            {
                                Category = g.Key,
                                maxTotalDue = g.Max(order=> order.TotalDue)
                            };
                Console.WriteLine("Lista de Sales Person y su maximo total en ventas: ");
                foreach (var order  in query)
                {
                    Console.WriteLine("Category: {0}\t  TotalDue Máximo:{1}",
                        order.Category, order.maxTotalDue);
                }
                Console.ReadKey();
            }
        }
    }
    
}
