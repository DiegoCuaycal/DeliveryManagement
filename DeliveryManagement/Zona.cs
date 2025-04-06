using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con otras tablas
        public List<Pedido>? Pedidos { get; set; }
    }
}
