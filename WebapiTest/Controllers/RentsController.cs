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
    public class RentsController : ControllerBase
    {
        IRentsLogic logic;
        IHubContext<SignalRHub> hub;

        public RentsController(IRentsLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("RentsCreated", value);
        }

       
        [HttpPut]
        public void Put([FromBody] Rents value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("RentsUpdated", value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("RentsDeleted", item);
        }
    }
}
