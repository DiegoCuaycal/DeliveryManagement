using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class VehiculoController : Controller
    {
        private string apiUrl;

        public VehiculoController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/Vehiculos"; // URL corregida
        }

        // GET: VehiculoController
        public async Task<IActionResult> Index()
        {
            var vehiculos = await Crud<Vehiculo>.Read_All(apiUrl);
            return View(vehiculos);
        }

        // GET: VehiculoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehiculo = await Crud<Vehiculo>.Read_ById(apiUrl, id);
            return View(vehiculo);
        }

        // GET: VehiculoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo data)
        {
            try
            {
                // Asegúrate de que Id no se envíe a la API si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<Vehiculo>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear el vehículo en la API. Verifica la conexión o los datos.");
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

        // GET: VehiculoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehiculo = await Crud<Vehiculo>.Read_ById(apiUrl, id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vehiculo data)
        {
            try
            {
                bool resultado = Crud<Vehiculo>.Update(apiUrl, id, data);

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el vehículo.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }



        // GET: VehiculoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var vehiculo = await Crud<Vehiculo>.Read_ById(apiUrl, id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<Vehiculo>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar el vehículo.");
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

