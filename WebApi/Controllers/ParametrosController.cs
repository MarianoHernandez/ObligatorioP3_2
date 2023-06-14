using Aplicacion.AplicacionesTipoCabania;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ExcepcionesPropias;
using Negocio.EntidadesAuxiliares;

using PresentacionMVC.Models;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Negocio.EntidadesAuxiliares;

namespace PresentacionMVC.Controllers
{
    public class ParametrosController : Controller
    {
        IValidarSession ValidarLogin { get; set; }
        IUpdateParametro UpdateParametro { get; set; }
        public ParametrosController(IValidarSession validar,IUpdateParametro update) {
            ValidarLogin = validar;
            UpdateParametro = update;
        }

        // GET: ParametrosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParametrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: ParametrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParametrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parametro param)
        {
            return RedirectToAction(nameof(Index), "Cabania");
        }
        

        // GET: ParametrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParametrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parametro param)
        {
            try
            {

                try
                {
                    string userEmail = HttpContext.Session.GetString("user");
                    ValidarLogin.Validar(userEmail);
                    param.Validar();

                    UpdateParametro.Update(param);


                    return RedirectToAction(nameof(Index), "Cabania");
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
            catch
            {
                return View();
            }
        }

        // GET: ParametrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParametrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
