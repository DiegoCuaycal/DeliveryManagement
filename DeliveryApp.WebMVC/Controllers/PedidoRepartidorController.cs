using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class PedidoRepartidorController : Controller
    {
        private readonly string apiUrl;

        public PedidoRepartidorController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/PedidoRepartidores"; // URL corregida
        }

        // GET: PedidoRepartidorController
        public async Task<IActionResult> Index()
        {
            var pedidoRepartidores = await Crud<PedidoRepartidor>.Read_All(apiUrl);
            return View(pedidoRepartidores);
        }

        // GET: PedidoRepartidorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pedidoRepartidor = await Crud<PedidoRepartidor>.Read_ById(apiUrl, id);
            return View(pedidoRepartidor);
        }

        // GET: PedidoRepartidorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoRepartidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoRepartidor data)
        {
            try
            {
                // Asegurar que el ID no se envíe si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<PedidoRepartidor>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al asignar el pedido al repartidor en la API.");
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

        // GET: PedidoRepartidorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pedidoRepartidor = await Crud<PedidoRepartidor>.Read_ById(apiUrl, id);
            return View(pedidoRepartidor);
        }

        // POST: PedidoRepartidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PedidoRepartidor data)
        {
            try
            {
                bool resultado = Crud<PedidoRepartidor>.Update(apiUrl, id, data); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar la asignación del pedido al repartidor.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: PedidoRepartidorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoRepartidor = await Crud<PedidoRepartidor>.Read_ById(apiUrl, id);
            return View(pedidoRepartidor);
        }

        // POST: PedidoRepartidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<PedidoRepartidor>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar la asignación del pedido al repartidor.");
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
