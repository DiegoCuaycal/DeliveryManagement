using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.WebMVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly string apiUrl;

        public PedidoController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/Pedidos"; // URL corregida
        }

        // GET: PedidoController
        public async Task<IActionResult> Index()
        {
            var pedidos = await Crud<Pedido>.Read_All(apiUrl);
            return View(pedidos);
        }

        // GET: PedidoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pedido = await Crud<Pedido>.Read_ById(apiUrl, id);
            return View(pedido);
        }

        // GET: PedidoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido data)
        {
            try
            {
                // Asegurar que el ID no se envíe si es autoincremental en SQL Server
                data.Id = 0;

                var resultado = await Crud<Pedido>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear el pedido en la API.");
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

        // GET: PedidoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await Crud<Pedido>.Read_ById(apiUrl, id);
            return View(pedido);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pedido data)
        {
            try
            {
                bool resultado = Crud<Pedido>.Update(apiUrl, id, data); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el pedido.");
                    return View(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: PedidoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await Crud<Pedido>.Read_ById(apiUrl, id);
            return View(pedido);
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool resultado = Crud<Pedido>.Delete(apiUrl, id); // Sin await

                if (!resultado)
                {
                    ModelState.AddModelError("", "No se pudo eliminar el pedido.");
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

