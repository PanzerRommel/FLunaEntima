using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace BL
{
    public class CatalogoProducto
    {
        public static ML.Result Add(ML.Catalogo catalogo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaEntimaContext context = new DL.FlunaEntimaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"InsCatalogoProd '{catalogo.Descripcion}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaEntimaContext context = new DL.FlunaEntimaContext())
                {
                    var query = context.CatalogoProductos.FromSqlRaw("GetAllCatalogoProd").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Catalogo catalogo = new ML.Catalogo()
                            {
                                IdProducto = obj.IdProducto,
                                Descripcion = obj.Descripcion,
                                IdUsuario = obj.IdProducto,
                                FechaCreacion = obj.FechaCreacion.Value
                            };
                            result.Objects.Add(catalogo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaEntimaContext context = new DL.FlunaEntimaContext())
                {
                    var producto = context.CatalogoProductos.FirstOrDefault(e => e.IdProducto == IdProducto);

                    if (producto != null)
                    {
                        context.CatalogoProductos.Remove(producto);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el empleado para eliminar.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaEntimaContext context = new DL.FlunaEntimaContext())
                {
                    var objquery = context.CatalogoProductos.FromSqlRaw($"GetByIdCatalogoProducto {IdProducto}").AsEnumerable().FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Catalogo catalogo = new ML.Catalogo();
                        catalogo.IdProducto = objquery.IdProducto;
                        catalogo.Descripcion = objquery.Descripcion;
                        catalogo.IdUsuario = objquery.IdUsuario.Value;
                        catalogo.FechaCreacion = objquery.FechaCreacion.Value;

                        result.Object = catalogo;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo completar los registros de la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Catalogo catalogo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaEntimaContext context = new DL.FlunaEntimaContext())
                {
                    var query = context.Database.ExecuteSqlRaw(
                        $"EXEC UpdateCatalogoProducto @Descripcion = '{catalogo.Descripcion}', @IdProducto = {catalogo.IdProducto}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}

