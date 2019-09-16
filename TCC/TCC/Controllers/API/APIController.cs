using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using TCC.Models;
using TCC.ViewModels;

namespace TCC.Controllers.API
{
    public class APIController : ApiController
    {
        [HttpPost]
        [Route("Api/PostRelatorio")]
        public async Task<HttpResponseMessage> PostRelatorio([FromBody] RelatoriosModel m)
        {
            try
            {
                using (var db = new Entities())
                {
                    if (m == null)
                        throw new Exception("Valores Enviados Incorretamente");

                    if(m.humidade == 0)
                        throw new Exception("Valor humidade incorreto");
                    if (m.IdPlanta == 0)
                        throw new Exception("Valor IdPlanta incorreto");
                    if (m.IdSensor == 0)
                        throw new Exception("Valor IdSensor incorreto");

                    var userPlant = new UserPlant()
                    {
                        Active = true,
                        Humidity = m.humidade,
                        IdPlant = m.IdPlanta,
                        IdSensor = m.IdSensor,
                        IdUser = 1,
                        ReadingTime = DateTime.Now,
                    };
                    db.UserPlant.Add(userPlant);
                    await db.SaveChangesAsync();

                    return Request.CreateResponse(HttpStatusCode.OK, "Registro Salvo Com Sucesso.");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Erro: {ex.Message}");
            }
        }

        //[HttpPost]
        //[Route("Api/AddSensore")]
        //public async Task<HttpResponseMessage> AddSensor([FromBody] dynamic m)
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            if (m == null)
        //                throw new Exception("Valores Enviados Incorretamente");

        //            if (!string.IsNullOrEmpty(m.Description))
        //                throw new Exception("Valor humidade incorreto");
        //            if (m.Id == 0)
        //                throw new Exception("Valor IdPlanta incorreto");
        //            if (m.Active == 0)
        //                throw new Exception("Valor IdSensor incorreto");

        //            var sensor = new Sensor()
        //            {
        //                Active = true,
        //                Description = m.Description
        //            };
        //            db.Sensor.Add(sensor);
        //            await db.SaveChangesAsync();

        //            return Request.CreateResponse(HttpStatusCode.OK, "Registro Salvo Com Sucesso.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Erro: {ex.Message}");
        //    }
        //}

        //[HttpGet]
        //[Route("Api/GetSensores")]
        //public HttpResponseMessage GetSensores()
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            var sensores = db.Sensor.Where(w => w.Active)
        //                .Select(s => new {
        //                    IdSensor = s.Id,
        //                    s.Description
        //                }).ToList();

        //            var data = new JavaScriptSerializer().Serialize(sensores);

        //            return Request.CreateResponse(HttpStatusCode.OK, data);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Erro: {ex.Message}");
        //    }
        //}
    }
}