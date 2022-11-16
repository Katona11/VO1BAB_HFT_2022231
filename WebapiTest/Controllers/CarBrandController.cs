using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        ICarBrandLogic logic;

        public CarBrandController(ICarBrandLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CarBrandController>
        [HttpGet]
        public IEnumerable<CarBrand> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarBrandController>/5
        [HttpGet("{id}")]
        public CarBrand Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarBrandController>
        [HttpPost]
        public void Create([FromBody] CarBrand value)
        {
            logic.Create(value);
        }

        // PUT api/<CarBrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarBrand value)
        {
            logic.Update(value);
        }

        // DELETE api/<CarBrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
