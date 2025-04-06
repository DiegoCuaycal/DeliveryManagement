using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class DetallePedidoController : Controller
    {
        private readonly string apiUrl;

        public DetallePedidoController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/DetallePedidos"; // URL corregida
        }

        // GET: DetallePedidoController
        public async Task<IActionResult> Index()
        {
            var detallesPedidos = await Crud<DetallePedido>.Read_All(apiUrl);
            return View(detallesPedidos);
        }

        // GET: DetallePedidoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var detallePedido = await Crud<DetallePedido>.Read_ById(apiUrl, id);
            return View(detallePedido);
        }

        // GET: DetallePedidoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetallePedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetallePedido data)
        {
            try
            {
                // Asegurar que el ID no se envíe si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<DetallePedido>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear el detalle del pedido en la API.");
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

        // GET: DetallePedidoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var detallePedido = await Crud<DetallePedido>.Read_ById(apiUrl, id);
            return View(detallePedido);
        }

        // POST: DetallePedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DetallePedido data)
        {
            try
            {
                bool resultado = Crud<DetallePedido>.Update(apiUrl, id, data); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el detalle del pedido.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: DetallePedidoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var detallePedido = await Crud<DetallePedido>.Read_ById(apiUrl, id);
            return View(detallePedido);
        }

        // POST: DetallePedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<DetallePedido>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar el detalle del pedido.");
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
