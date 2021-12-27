using Microsoft.AspNetCore.Mvc;
using WCore.Models;

namespace WCore.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDAL usu;
        public UsuarioController(IUsuarioDAL usuario)
        {
            usu = usuario;
        }
        public IActionResult Index()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = usu.GetAllUsuarios().ToList();
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = usu.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usu.AddUsuario(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = usu.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                usu.UpdateUsuario(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = usu.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            usu.DeleteUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
