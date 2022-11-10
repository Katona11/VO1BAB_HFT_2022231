using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Endpoint.Controllers
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

        [HttpGet]
        public IEnumerable<Cars> Get()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Cars Get(int id)
        {
            return this.logic.Read(id);
                
        }

        
        [HttpPost]
        public void Post([FromBody] Cars value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut("{id}")]
        public void Put([FromBody] Cars value)
        {
            this.logic.Update(value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
