using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarLogic logic;

        public CarsController(ICarLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<Cars> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Cars Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Create([FromBody] Cars value)
        {
            logic.Create(value);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cars value)
        {
            logic.Update(value);
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
