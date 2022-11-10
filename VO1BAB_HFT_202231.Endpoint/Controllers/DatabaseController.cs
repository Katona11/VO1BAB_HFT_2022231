using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;

namespace VO1BAB_HFT_202231.Endpoint.Controllers
{

    [Route("api/[controller]/[actions]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        ICarLogic carslogic;

        public DatabaseController(ICarLogic carslogic)
        {
            this.carslogic = carslogic;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IEnumerable<int> TheMostFamousBrand()
        {
            return carslogic.TheMostFamousBrand();
        }
    }
}
