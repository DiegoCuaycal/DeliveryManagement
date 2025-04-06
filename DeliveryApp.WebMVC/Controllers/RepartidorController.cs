using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class RepartidorController : Controller
    {
        private readonly string apiUrl;

        public RepartidorController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/Repartidores"; // URL corregida
        }

        // GET: RepartidorController
        public async Task<IActionResult> Index()
        {
            var repartidores = await Crud<Repartidor>.Read_All(apiUrl);
            return View(repartidores);
        }

        // GET: RepartidorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var repartidor = await Crud<Repartidor>.Read_ById(apiUrl, id);
            return View(repartidor);
        }

        // GET: RepartidorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepartidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Repartidor data)
        {
            try
            {
                // Asegurar que el ID no se envíe si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<Repartidor>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear el repartidor en la API.");
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

        // GET: RepartidorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var repartidor = await Crud<Repartidor>.Read_ById(apiUrl, id);
            return View(repartidor);
        }

        // POST: RepartidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Repartidor data)
        {
            try
            {
                bool resultado = Crud<Repartidor>.Update(apiUrl, id, data); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el repartidor.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: RepartidorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var repartidor = await Crud<Repartidor>.Read_ById(apiUrl, id);
            return View(repartidor);
        }

        // POST: RepartidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<Repartidor>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar el repartidor.");
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

