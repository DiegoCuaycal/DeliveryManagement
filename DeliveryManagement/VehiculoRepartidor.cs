using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class VehiculoRepartidor
    {
        public int Id { get; set; }

        // Relaciones Foráneas
        public int RepartidorId { get; set; }
        public int VehiculoId { get; set; }

        // Relación con otras tablas
        public Repartidor? Repartidor { get; set; }
        public Vehiculo? Vehiculo { get; set; }
    }
}
