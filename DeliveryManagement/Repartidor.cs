using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class Repartidor
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string TipoLicencia { get; set; } // Tipo de licencia de conducir (A, B, C, etc.)
        public string Direccion { get; set; } // Dirección del repartidor

        // Relaciones con otras Entidades
        public List<Pedido>? Pedidos { get; set; } // Relación con pedidos asignados
        public List<VehiculoRepartidor>? VehiculoRepartidores { get; set; } // Relación con los vehículos asignados
    }
}
