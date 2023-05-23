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

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarLogic logic;
        IHubContext<SignalRHub> hub;

        public CarsController(ICarLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("CarsCreated", value);
        }

        
        [HttpPut]
        public void Put([FromBody] Cars value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CarsUpdated", value);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var items = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarsDeleted", items);
        }
    }
}
