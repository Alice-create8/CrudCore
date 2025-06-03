using Microsoft.AspNetCore.Mvc;
using CrudCore1.Datos;
using CrudCore1.Models;


namespace CrudCore1.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            /*LA VISTA MOSTRARA UN LISTA DE CONTACTOS*/
            var oLista = _contactoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            /*METODO SOLO DEVUELVE LA VISTA*/
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(ContactoModel oContacto)
        {
            /*METODO RECIBE OBJETO PARA GUARDALO EN DB*/

            if(!ModelState.IsValid)

                return View();

            var respuesta = _contactoDatos.Guardar(oContacto);
            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }
        public IActionResult Editar(int IdContacto)
        {
            /*METODO SOLO DEVUELVE LA VISTA*/
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]

        public IActionResult Editar(ContactoModel oContacto)
        {
            /*METODO RECIBE OBJETO PARA GUARDALO EN DB*/
            if (!ModelState.IsValid)
               return View();

            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }
        public IActionResult Eliminar(int IdContacto)
        {
            /*METODO SOLO DEVUELVE LA VISTA*/
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]

        public IActionResult Eliminar(ContactoModel oContacto)
        {
            /*METODO RECIBE OBJETO PARA GUARDALO EN DB*/
            

            var respuesta = _contactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)

                return RedirectToAction("Listar");

            else
                return View();
        }

    }
}
