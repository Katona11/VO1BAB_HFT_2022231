using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_20231.Endpoint.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        ICarBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public CarBrandController(ICarBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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

       
        [HttpPost]
        public void Create([FromBody] CarBrand value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("CarBrandCreated", value);
        }

        
        [HttpPut]
        public void Put([FromBody] CarBrand value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CarBrandUpdated", value);
        }

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carsbrandtodelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarBrandDeleted", carsbrandtodelete);
        }
    }
}
