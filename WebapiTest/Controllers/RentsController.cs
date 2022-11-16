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
    public class RentsController : ControllerBase
    {
        IRentsLogic logic;

        public RentsController(IRentsLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<RentsController>
        [HttpGet]
        public IEnumerable<Rents> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<RentsController>/5
        [HttpGet("{id}")]
        public Rents Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<RentsController>
        [HttpPost]
        public void Create([FromBody] Rents value)
        {
            logic.Create(value);
        }

        // PUT api/<RentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rents value)
        {
            logic.Update(value);
        }

        // DELETE api/<RentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
