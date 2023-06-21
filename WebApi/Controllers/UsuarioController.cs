using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.InterfacesRepositorio;
using System.Net;
using WebAPI;

namespace PresentacionMVC.Controllers
{
    public class UsuarioController : Controller
    {

        IAltaUsuario AltaUsuario { get; set; }
        ILoginUsuario LoginUsuario { get; set; }
        public UsuarioController(IAltaUsuario altaUsuario, ILoginUsuario loginUsuario)
        {
            AltaUsuario = altaUsuario;
            LoginUsuario = loginUsuario;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            
            return View();

        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.Clear();
            }
            TempData["Bien"] = "Logout";

            return RedirectToAction("Login", "Usuario");
        }


        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            try
            {

                UsuarioDTO logueado = LoginUsuario.Login(usuario.Email, usuario.Password);
                return Ok(new DTOLogin() { Rol = logueado.Rol, TokenJWT = ManejadorJWT.GenerarToken(logueado) });
            }
            catch (LoginIncorrectoException ex)
            {
                return Unauthorized("El usuario o la contraseña no son correctos");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
