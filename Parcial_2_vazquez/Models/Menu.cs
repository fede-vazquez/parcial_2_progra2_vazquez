using Panaderia.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Panaderia.Models
{
    public static class Menu
    {
        static List<Action> Acciones = new List<Action>
        {
            AgregarProducto,
            EliminarProducto,
            ModificarProducto,
            MostrarProductos
        };

        public static void MostrarMenu()
        {
            GestionProductos.CargarProductos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n---- Menú ----\n" +
                    "1. Agregar producto\n" +
                    "2. Eliminar producto\n" +
                    "3. Modificar producto\n" +
                    "4. Mostrar productos\n" +
                    "5. Salir");

                Console.Write("Opción: ");
                string seleccion = Console.ReadLine();

                if(int.TryParse(seleccion, out int indice) && indice > 0 && indice <= Acciones.Count + 1)
                {
                    if(indice == Acciones.Count + 1)
                    {
                        salir = true;
                        Console.WriteLine("Saliendo...");
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
                else
                {
                    Console.WriteLine("\nOpción incorrecta");
                }
            }
        }

        public static void AgregarProducto()
        {
            Console.Write("\nIngrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("\nIngrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Categoria categoria = MostrarObtenerCategoria();

            Console.Write("\nIngrese el stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            Producto p = new Producto(nombre, precio, categoria, stock);
            GestionProductos.AgregarProducto(p);
        }

        public static void EliminarProducto()
        {
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            string nombreProducto = Console.ReadLine();

            GestionProductos.EliminarProducto(nombreProducto);
        }

        public static void ModificarProducto()
        {
            Console.Write("\nIngrese el nombre del producto a modificar: ");
            string nombre = Console.ReadLine();

            Console.Write("\nIngrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Categoria categoria = MostrarObtenerCategoria();

            Console.Write("\nIngrese el stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            GestionProductos.ModificarProducto(nombre, precio, categoria, stock);
        }

        private static Categoria MostrarObtenerCategoria()
        {
            Console.WriteLine("\nCategorias posibles:");
            foreach (var c in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine($"{(int)c}.{c}");
            }

            Console.Write("Ingrese el número de la categoria del producto:");
            int seleccion = int.Parse(Console.ReadLine());
            return (Categoria)seleccion;
        }

        public static void MostrarProductos() => GestionProductos.MostrarProductos();
    }
}
