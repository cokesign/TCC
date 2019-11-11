using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TCC.Models;
using TCC.ViewModels;

namespace TCC.Controllers.API
{
    public class APIController : ApiController
    {
        [HttpPost]
        [Route("Api/PostRelatorio")]
        public async Task<HttpResponseMessage> PostRelatorio([FromBody] RelatoriosViewModel m)
        {
            try
            {
                using (var db = new Entities())
                {
                    if (m == null)
                        throw new Exception("Valores Enviados Incorretamente");

                    if(m.Umidade == 0)
                        throw new Exception("Valor humidade incorreto");
                    if (m.IdPlanta == 0)
                        throw new Exception("Valor IdPlanta incorreto");
                    if (m.IdSensor == 0)
                        throw new Exception("Valor IdSensor incorreto");

                    var userPlant = new UserPlant()
                    {
                        Active = true,
                        Humidity = m.Umidade,
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

        [HttpGet]
        [Route("Api/ConfigInicial")]
        public string ConfigInicial()
        {
            try
            {
                using (var db = new Entities())
                {
                    var config = db.Configuration.Find(1);

                    var obj = $"{config.Minutes ?? 30}";
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}