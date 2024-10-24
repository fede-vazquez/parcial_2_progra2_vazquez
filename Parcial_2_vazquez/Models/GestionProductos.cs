using Panaderia.Enums;

namespace Panaderia.Models
{
    public static class GestionProductos
    {
        private static Dictionary<string, Producto> Productos = new Dictionary<string, Producto>();

        public static void AgregarProducto(Producto p)
        {
            Productos.Add(p.Nombre, p);
            SysArchivo.GuardarProducto(p);
            Console.WriteLine($"\nProducto '{p.Nombre}' creado.");
        }

        public static void EliminarProducto(string nombreProducto)
        {
            if (Productos.ContainsKey(nombreProducto))
            {
                Productos.Remove(nombreProducto);
                GuardarProductos();
                Console.WriteLine($"\nProducto {nombreProducto} eliminado.");
            }
            else
            {
                Console.WriteLine($"\nEl producto {nombreProducto} no existe.");
            }
        }

        public static void ModificarProducto(string nombreProducto, decimal nuevoPrecio, Categoria nuevaCategoria, int nuevoStock)
        {
            if (Productos.ContainsKey(nombreProducto))
            {
                Productos[nombreProducto].ModificarProducto(nuevoPrecio, nuevaCategoria, nuevoStock);
                GuardarProductos();

                Console.WriteLine($"\nProducto {nombreProducto} modificado");
            }
            else
            {
                Console.WriteLine($"\nEl producto {nombreProducto} no existe.");
            }
        }

        public static void MostrarProductos()
        {
            if(Productos.Count > 0)
            {
                Console.WriteLine("\nProductos en stock: ");
                foreach (var p in Productos.Values)
                {
                    Console.WriteLine($"{p.Nombre}, {p.Categoria}, precio: {p.Precio}, stock: {p.CantidadStock}");
                }
                CalcularMostrarPrecioTotalProductos();
            }
            else
            {
                Console.WriteLine("\nNo hay productos.");
            }
        }

        // Calcula y muestra por consola el precio total de los productos. Multiplicando el precio unicario por la cantidad en stock.
        private static void CalcularMostrarPrecioTotalProductos()
        {
            decimal total = Productos.Values.Sum(p => p.Precio * p.CantidadStock);
            Console.WriteLine($"\nLa suma total de los productos es de ${total}");
        }

        public static void GuardarProductos() => SysArchivo.GuardarDatos(Productos);
        public static void CargarProductos() => Productos = SysArchivo.CargarDatos();
    }
}
