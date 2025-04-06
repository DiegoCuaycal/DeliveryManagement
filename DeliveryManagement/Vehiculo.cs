using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; } // Placa del vehículo
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CapacidadCarga { get; set; } // Capacidad en kg o volumen
        public string Tipo { get; set; } // Motocicleta, Furgoneta, Camión, etc.

        // Relación con otras tablas
        public List<VehiculoRepartidor>? VehiculoRepartidores { get; set; }
    }
}
