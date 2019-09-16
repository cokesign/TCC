using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TCC.Models;

namespace TCC.Controllers.API
{
    public static class Simulador
    {
        public static void ExecutaSimulador(int number)
        {
            try
            {
                Thread t3 = new Thread(p =>
                {
                    using (var db = new Entities())
                    {
                        while (true)
                        {
                            var plantas = db.Plant.ToList();
                            var sensores = db.Sensor.ToList();

                            var randomPlantas = new Random().Next(plantas.Min(m => m.Id), plantas.Max(m => m.Id));
                            var randomSensores = new Random().Next(sensores.Min(m => m.Id), sensores.Max(m => m.Id));

                            var userPlant = new UserPlant()
                            {
                                IdPlant = randomPlantas,
                                IdSensor = randomSensores,
                                IdUser = 1,
                                Active = true,
                                ReadingTime = DateTime.Now,
                                Humidity = new Random().Next(1, 200)
                            };
                            db.UserPlant.Add(userPlant);
                            db.SaveChanges();
                            Thread.Sleep(number);
                        }
                    }
                });
                t3.Start();
            }
            catch(Exception e)
            {

            }
        }
    }
}