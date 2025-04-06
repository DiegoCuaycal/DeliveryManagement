using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Destinatario { get; set; }
        public float Peso { get; set; }
        public string DireccionDestino { get; set; }

        // Claves Foráneas
        public int ZonaId { get; set; } // Antes "ProvinciaId"
        public int DetallePedidoId { get; set; } // Antes "DetallePaqueteId"
        public int RepartidorId { get; set; } // Antes "ConductorId"

        // Relación con otras Tablas
        public Zona? Zona { get; set; } // Antes "Provincia"
        public DetallePedido? DetallePedido { get; set; } // Antes "DetallePaquete"
        public Repartidor? Repartidor { get; set; } // Antes "Conductor"
    }
}
