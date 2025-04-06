using Delivery.ConsumeAPI;
using DeliveryManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DeliveryApp.WebMVC.Controllers
{
    public class ZonaController : Controller
    {
        private  string apiUrl;

        public ZonaController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiURL"] + "/Zonas"; // Corregido: 'Zonas' en plural
        }


        // GET: ZonaController

        public async Task<IActionResult> Index()
        {
            var zonas = await Crud<Zona>.Read_All(apiUrl);
            return View(zonas);
        }

        // GET: ZonaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var zona = await Crud<Zona>.Read_ById(apiUrl, id);
            return View(zona);
        }


        // GET: ZonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Zona data)
        {
            try
            {
                // Asegúrate de que Id no se envíe a la API (eliminarlo si es autoincremental en SQL Server)
                data.Id = 0; // O data.Id = null; si lo permitiera el modelo

                var resultado = await Crud<Zona>.Create(apiUrl, data);

                if (resultado == null)
                {
                    ModelState.AddModelError("", "Error al crear la zona en la API. Verifica la conexión o los datos.");
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




        // GET: ZonaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var zona = await Crud<Zona>.Read_ById(apiUrl, id);
            return View(zona);
        }


        // POST: ZonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Zona data)
        {

            try
            {
                Crud<Zona>.Update(apiUrl, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Mensaje de error
                return View(data);
            }
        }

        // GET: ZonaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var zona = await Crud<Zona>.Read_ById(apiUrl, id);
            return View(zona);
        }


        // POST: ZonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Zona data)
        {
            try
            {
                Crud<Zona>.Delete(apiUrl, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Mensaje de error
                return View(data);
            }
        }
    }
}
