using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class PedidoRepartidor
    {
        public int Id { get; set; }
        public string Destinatario { get; set; }
        public float Peso { get; set; }
        public string DireccionDestino { get; set; }
        public string ZonaDestino { get; set; } // Antes "ProvinciaNombre"
        public string DetalleDescripcion { get; set; }
        public float DetallePrecio { get; set; }
        public string RepartidorNombre { get; set; }
        public string RepartidorApellido { get; set; }
    }
}
