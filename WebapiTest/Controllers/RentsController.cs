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
    [Route("[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRentsLogic logic;

        public RentsController(IRentsLogic logic)
        {
            this.logic = logic;
        }

        
        [HttpGet]
        public IEnumerable<Rents> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Rents Read(int id)
        {
            return logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Rents value)
        {
            logic.Create(value);
        }

       
        [HttpPut]
        public void Put([FromBody] Rents value)
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
