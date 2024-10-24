using Panaderia.Enums;

namespace Panaderia.Models
{
    public class Producto
    {
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public Categoria Categoria { get; private set; }
        public int CantidadStock { get; private set; }

        public Producto(string nombre, decimal precio, Categoria categoria, int cantidadStock)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            CantidadStock = cantidadStock;
        }

        public void ModificarProducto(decimal nuevoPrecio, Categoria nuevaCategoria, int nuevoStock)
        {
            Precio = nuevoPrecio;
            Categoria = nuevaCategoria;
            CantidadStock = nuevoStock;
        }

        public override string ToString() => $"{Nombre}, {Precio}, {Categoria}, {CantidadStock}";
    }
}