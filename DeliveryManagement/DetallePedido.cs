using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class DetallePedido
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; } // Número de unidades del producto
        public float Subtotal { get; set; } // Precio * Cantidad

        // Relación con otras tablas
        public List<Pedido>? Pedidos { get; set; }
    }
}
