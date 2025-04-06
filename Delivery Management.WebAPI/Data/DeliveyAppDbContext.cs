using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeliveryManagement;

    public class DeliveyAppDbContext : DbContext
    {
        public DeliveyAppDbContext (DbContextOptions<DeliveyAppDbContext> options)
            : base(options)
        {
        }

        //public DbSet<DeliveryManagement.Restaurante> Restaurantees { get; set; } = default!;

        public DbSet<DeliveryManagement.Pedido> Pedidos { get; set; } = default!;


        public DbSet<DeliveryManagement.Repartidor> Repartidor { get; set; } = default!;

        public DbSet<DeliveryManagement.Vehiculo> Vehiculo { get; set; } = default!;

public DbSet<DeliveryManagement.Zona> Zona { get; set; } = default!;

public DbSet<DeliveryManagement.DetallePedido> DetallePedido { get; set; } = default!;

public DbSet<DeliveryManagement.PedidoRepartidor> PedidoRepartidor { get; set; } = default!;

public DbSet<DeliveryManagement.VehiculoRepartidor> VehiculoRepartidor { get; set; } = default!;
    }
