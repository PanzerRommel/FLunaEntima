using Microsoft.AspNetCore.Mvc;

namespace FLunaEntima.Controllers
{
    public class CatalogoProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Catalogo catalogo = new ML.Catalogo();
            ML.Result result = BL.CatalogoProducto.GetAll();
            if (result.Correct)
            {
                catalogo.Catalogos = result.Objects;
            }
            return View(catalogo);
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Catalogo catalogo = new ML.Catalogo();
            if (IdProducto == null)
            {
                return View(catalogo);
            }
            else
            {
                ML.Result result = BL.CatalogoProducto.GetById(IdProducto.Value);

                if (result.Correct)
                {
                    catalogo = ((ML.Catalogo)result.Object);

                    return View(catalogo);
                }
                else
                {
                    ViewBag.Mensaje = "Se produjo un error" + result.ErrorMessage;
                    return View("Modal");
                }

            }
        }

        [HttpPost]
        public ActionResult Form(ML.Catalogo catalogo)
        {
            ML.Result result = new ML.Result();
            if(catalogo.IdProducto == 0)
            {
                result = BL.CatalogoProducto.Add(catalogo);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registro de manera exitosa";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrió un problema al agregar el registro";
                }
                return PartialView("Modal");
            }
            else
            {
                result = BL.CatalogoProducto.Update(catalogo);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizacion extisosa";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un problema al actualizar descripcion";
                }
                return PartialView("Modal");

            }
            return View(catalogo);
        }
        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result = BL.CatalogoProducto.Delete(IdProducto);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro Eliminado Con Exitoso";
            }
            else
            {
                ViewBag.Mensaje = "Se A Producido Un Error" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

    }
}
