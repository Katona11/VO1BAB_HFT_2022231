using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarLogic logic;

        public CarsController(ICarLogic logic)
        {
            this.logic = logic;
        }


       
        [HttpGet]
        public IEnumerable<Cars> ReadAll()
        {
            return logic.ReadAll();
        }

       
        [HttpGet("{id}")]
        public Cars Read(int id)
        {
            return logic.Read(id);
        }

       
        [HttpPost]
        public void Create([FromBody] Cars value)
        {
            logic.Create(value);
        }

        
        [HttpPut]
        public void Put([FromBody] Cars value)
        {
            logic.Update(value);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
