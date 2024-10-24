using Panaderia.Enums;

namespace Panaderia.Models
{
    public static class SysArchivo
    {
        static string nombreArchivo = "../../../productos.txt";

        public static void GuardarDatos(Dictionary<string, Producto> productos)
        {
            using StreamWriter writer = new StreamWriter(nombreArchivo);
            foreach (var p in productos.Values)
            {
                writer.WriteLine(p);
            }
        }

        public static void GuardarProducto(Producto p)
        {
            using StreamWriter writer = new StreamWriter(nombreArchivo, true);
            writer.WriteLine(p);
        }

        public static Dictionary<string, Producto> CargarDatos()
        {
            Dictionary<string, Producto> productos = new Dictionary<string, Producto>();

            if (!File.Exists(nombreArchivo)) return productos;

            foreach (var linea in File.ReadAllLines(nombreArchivo))
            {
                string[] partes = linea.Split(", ");

                string nombre = partes[0];
                decimal precio = decimal.Parse(partes[1]);
                Categoria categoria = (Categoria)Enum.Parse(typeof(Categoria), partes[2]);
                int stock = int.Parse(partes[3]);

                Producto p = new Producto(nombre, precio, categoria, stock);

                productos.Add(nombre, p);
            }

            return productos;
        }
    }
}
