using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class VehiculoRepartidorController : Controller
    {
        private readonly string apiUrl;

        public VehiculoRepartidorController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/VehiculoRepartidores"; // URL corregida
        }

        // GET: VehiculoRepartidorController
        public async Task<IActionResult> Index()
        {
            var vehiculoRepartidores = await Crud<VehiculoRepartidor>.Read_All(apiUrl);
            return View(vehiculoRepartidores);
        }

        // GET: VehiculoRepartidorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehiculoRepartidor = await Crud<VehiculoRepartidor>.Read_ById(apiUrl, id);
            return View(vehiculoRepartidor);
        }

        // GET: VehiculoRepartidorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoRepartidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculoRepartidor data)
        {
            try
            {
                // Asegurar que el ID no se envíe si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<VehiculoRepartidor>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear la asignación de vehículo y repartidor en la API.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error: " + ex.Message);
                return View(data);
            }
        }

        // GET: VehiculoRepartidorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehiculoRepartidor = await Crud<VehiculoRepartidor>.Read_ById(apiUrl, id);
            return View(vehiculoRepartidor);
        }

        // POST: VehiculoRepartidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VehiculoRepartidor data)
        {
            try
            {
                bool resultado = Crud<VehiculoRepartidor>.Update(apiUrl, id, data); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar la asignación de vehículo y repartidor.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }


        // GET: VehiculoRepartidorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var vehiculoRepartidor = await Crud<VehiculoRepartidor>.Read_ById(apiUrl, id);
            return View(vehiculoRepartidor);
        }

        // POST: VehiculoRepartidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<VehiculoRepartidor>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar la asignación de vehículo y repartidor.");
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
