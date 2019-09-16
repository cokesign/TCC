using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ValuesController : ApiController
    {
        private List<Sensor> Sensores { get; set; }
        private List<Plant> Plantas { get; set; }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }

        private class Sensor
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Active { get; set; }
        }

        private class Plant
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Active { get; set; }
            public int? IdCategory { get; set; }
        }

        private partial class UserPlant
        {
            public int Id { get; set; }
            public DateTime ReadingTime { get; set; }
            public bool Active { get; set; }
            public int IdPlant { get; set; }
            public int IdSensor { get; set; }
            public int IdUser { get; set; }
            public decimal Humidity { get; set; }
        }
    }
}
