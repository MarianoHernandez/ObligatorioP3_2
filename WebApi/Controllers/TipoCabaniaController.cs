using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Datos.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using PresentacionMVC.Models;
using System;


namespace PresentacionMVC.Controllers
{
    public class TipoCabaniaController : Controller
    {
        IAltaTipoCabania AltaTipoCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IFindByName FindByName { get; set; }
        IDeleteTipo DeleteTipo { get; set; }
        IUpdateTipo UpdateTipo { get; set; }
        IValidarSession ValidarLogin { get; set; }
        IFindCabaniaPorTipo FindCabaniaPorTipo { get; set; }

        IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }


        public TipoCabaniaController(IFindCabaniaPorTipo findCabaniaPorTipo, IAltaTipoCabania altaTipoCabania,IValidarSession validarSession, IListadoTipoCabania listadoTipoCabania, IFindByName findByName, IDeleteTipo deleteTipo, IUpdateTipo updateTipo, IObtenerMaxMinDescripcion obtenerMaxMin)
        {
            AltaTipoCabania = altaTipoCabania;
            ListadoTipoCabania = listadoTipoCabania;
            FindByName = findByName;
            DeleteTipo = deleteTipo;
            UpdateTipo = updateTipo;    
            ValidarLogin = validarSession;
            ObtenerMaxMin = obtenerMaxMin;
            FindCabaniaPorTipo = findCabaniaPorTipo;
        }


        // GET: TipoCabaniaController
        public ActionResult Index()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                IEnumerable<TipoCabania> tipos = ListadoTipoCabania.ObtenerListado();
                return View(tipos);
            }catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }


        public ActionResult FindOne(string accion) { 
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                EliminarOModificar EM = new EliminarOModificar();
                EM.Accion = accion;
                return View(EM); 
            }catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindOne(EliminarOModificar EM)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                if(EM.Accion == "Eliminar") return RedirectToAction(nameof(Delete), new { nombre = EM.Nombre });
                if(EM.Accion == "Editar") return RedirectToAction(nameof(Edit),new { nombre=EM.Nombre });
                return RedirectToAction(nameof(Details), new { nombre = EM.Nombre });
            }
            catch (NombreInvalidoException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // GET: TipoCabaniaController/Details/5
        public ActionResult Details(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                return View(tipo);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (NoEncontradoException ex) {
                TempData["Error"] = "No se encontro el Tipo";
                return RedirectToAction(nameof(FindOne), new { accion = "Detalle" });
            }

            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // GET: TipoCabaniaController/Create
        public ActionResult Create()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                return View();
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

        // POST: TipoCabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCabania tipoCabania)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);

                tipoCabania.Validar();
                AltaTipoCabania.Alta(tipoCabania);
                return RedirectToAction(nameof(Index));
            }
            catch (NombreInvalidoException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (DescripcionInvalidaException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException)
                {
                    SqlException sql = (SqlException)ex.InnerException;
                    if (sql.Number == 2601)
                    {
                        TempData["Error"] = "Nombre duplicacdo";
                        return View();
                    }

                }
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // GET: TipoCabaniaController/Delete/5
        public ActionResult Delete(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                return View(tipo);
            }
            catch (NoEncontradoException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // POST: TipoCabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string nombre,int id)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                IEnumerable<Cabania> cabanias = FindCabaniaPorTipo.FindByTipoCabania(nombre);
                if (cabanias.Count() != 0) throw new ExisteOtroElementoRelacionado("No se puede eliminar el Tipo ya que hay cabanias registradas con el tipo");
                DeleteTipo.DeleteTipo(nombre);
                return RedirectToAction(nameof(Index));
            }
            catch (NoEncontradoException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (ExisteOtroElementoRelacionado ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "TipoCabania");
            }

            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // GET: TipoCabaniaController/Edit/5
        public ActionResult Edit(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);

                return View(FindByName.FindOne(nombre));
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // POST: TipoCabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, TipoCabania tipoEditado)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                tipo.Costo = tipoEditado.Costo;
                tipo.Descripcion = tipoEditado.Descripcion;
                Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Tipo");

                tipo.Validar();
                UpdateTipo.Update(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

    }
}
