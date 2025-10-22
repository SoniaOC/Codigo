using System;
using System.Collections.Generic;

namespace TiendaConFachada
{
    public class Almacen
    {
        private Dictionary<string, decimal> inventario;

        public Almacen()
        {
            inventario = new Dictionary<string, decimal>()
            {
                { "Laptop HP Pavilion 15", 18499.99m },
                { "Audifonos inalambricos Sony", 2499.50m},
                { "Mouse Logitech G203", 599.99m },
                { "Teclado mecanico Redragon", 1299.00m }
            };
        }

        public bool VerificarStock(string producto)
        {
            if (inventario.ContainsKey(producto))
            {
                Console.WriteLine($"'{producto}' disponible en almacén.");
                return true;
            }
            else
            {
                Console.WriteLine($"El producto '{producto}' no existe en el inventario.");
                return false;
            }
        }

        public decimal ObtenerPrecio(string producto)
        {
            return inventario.ContainsKey(producto) ? inventario[producto] : 0;
        }

        public void MostrarProductos()
        {
            Console.WriteLine("Productos disponibles:");
            foreach (var item in inventario)
            {
                Console.WriteLine($"- {item.Key}: ${item.Value}");
            }
        }
    }

    public class Pago
    {
        public void ProcesarPago(string metodo, decimal monto)
        {
            Console.WriteLine($"Procesando pago de ${monto} con {metodo}...");
            Console.WriteLine("Pago aprobado.");
        }
    }

    public class Envio
    {
        public void GenerarEnvio(string direccion)
        {
            Console.WriteLine($"Enviando pedido a: {direccion}");
            Console.WriteLine("Envío realizado con éxito.");
        }
    }

    public class TiendaOnlineFacade
    {
        private Almacen almacen = new Almacen();
        private Pago pago = new Pago();
        private Envio envio = new Envio();

        public void MostrarCatalogo()
        {
            almacen.MostrarProductos();
        }

        public void RealizarCompra(string producto, string metodoPago, string direccion)
        {
            Console.WriteLine("\n--- Iniciando proceso de compra ---");

            if (almacen.VerificarStock(producto))
            {
                decimal precio = almacen.ObtenerPrecio(producto);
                Console.WriteLine($"Precio del producto: ${precio}");

                pago.ProcesarPago(metodoPago, precio);
                envio.GenerarEnvio(direccion);

                Console.WriteLine($"Compra de '{producto}' completada con éxito.");
            }

            Console.WriteLine("--- Fin del proceso ---\n");
        }
    }

    class Program
    {
        static void Main()
        {
            TiendaOnlineFacade tienda = new TiendaOnlineFacade();

            Console.WriteLine("Bienvenido a la Tienda Online");
            tienda.MostrarCatalogo();

            Console.Write("\nEscribe el nombre exacto del producto que deseas comprar: ");
            string producto = Console.ReadLine();

            Console.Write("Ingresa el método de pago (Tarjeta / PayPal): ");
            string metodo = Console.ReadLine();

            Console.Write("Ingresa tu dirección de envío: ");
            string direccion = Console.ReadLine();

            tienda.RealizarCompra(producto, metodo, direccion);

            Console.WriteLine("Gracias por tu compra.");
            Console.ReadKey();
        }
    }
}