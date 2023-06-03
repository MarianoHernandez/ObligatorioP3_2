using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Hosting;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using PresentacionMVC.Models;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentacionMVC.Controllers
{
    public class MantenimientoController : Controller
    {
        IAltaMantenimiento AltaMantenimiento { get; set; }
        IListadoMantenimiento ListadoMantenimiento { get; set; }
        IDeleteMantenimiento DeleteMantenimiento { get; set; }
        IValidarSession ValidarLogin { get; set; }
        IFindByDate FindByDates { get; set; }
        IListadoCabania ListadoCabania { get; set; }
        IWebHostEnvironment Env { get; set; }
        IFindByCabania FindByCabania { get; set; }
        IFindByIdCabania FindByIdCabania { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoMantenimiento listadoMantenimiento, IDeleteMantenimiento deleteMantenimiento,
           IValidarSession validarSession, IFindByDate findByDates, IWebHostEnvironment webHostEnvironment, IListadoCabania listadoCabania, IFindByCabania findByCabania,
            IFindByIdCabania findByIdCabania)
        {
            AltaMantenimiento = altaMantenimiento;
            ListadoMantenimiento = listadoMantenimiento;
            DeleteMantenimiento = deleteMantenimiento;
            ValidarLogin = validarSession;
            FindByDates = findByDates;
            Env = webHostEnvironment;
            ListadoCabania = listadoCabania;
            FindByCabania = findByCabania;
            FindByIdCabania = findByIdCabania;
        }

        // GET: ManteniminetoController
        public ActionResult Index()
        {

            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                return View(ListadoMantenimiento.ListadoAllMantenimientos());
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        // GET: ManteniminetoController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }
        public ActionResult ListByCabania(int id)
        {
            
            return View(FindByCabania.FindMantenimientoByCabania(id));
        }


        // GET: ManteniminetoController/Create
        public ActionResult Create(int id)
        {
            AltaMantenimientoViewModel vm = new AltaMantenimientoViewModel();

            vm.IdCabania = id;

            return View(vm);
        }

        // POST: ManteniminetoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaMantenimientoViewModel VmMantenimiento )
        {


            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);

                VmMantenimiento.MantenimientoNuevo.CabaniaId = VmMantenimiento.IdCabania;

                AltaMantenimiento.Alta(VmMantenimiento.MantenimientoNuevo);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ManteniminetoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManteniminetoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FindById()
        {
            return View();
        }

        public ActionResult FindByDate()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                BusquedaMantenimientoModel BusquedaModal = new BusquedaMantenimientoModel();
                return View(BusquedaModal);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }
        [HttpPost]
        public ActionResult FindByDate(DateTime fecha1, DateTime fecha2)
        {
            return RedirectToAction(nameof(MostrarMantenimientoFiltrado), new { fecha1, fecha2 });

        }

        public ActionResult MostrarMantenimientoFiltrado(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                IEnumerable<Mantenimiento> filtrados = FindByDates.FindByDateMantenimiento(Fecha1, Fecha2);
                return View(filtrados);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }



        // GET: ManteniminetoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: ManteniminetoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Mantenimiento mantenimiento)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                DeleteMantenimiento.DeleteMantenimiento(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch (NoEncontradoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error";
                return View();
            }
        }
        
    }
}
