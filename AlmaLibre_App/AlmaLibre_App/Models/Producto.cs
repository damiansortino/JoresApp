using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaLibre_App.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precioUnitario { get; set; }
        public double porcentajeRentabilidad { get; set; }
        public string talle { get; set; }
        public string color { get; set; }
        public string marca { get; set; }
        public string codigo { get; set; }
        public double precio { get; set; }
    }
}
