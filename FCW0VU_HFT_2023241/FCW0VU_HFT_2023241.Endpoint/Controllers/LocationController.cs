using FCW0VU_HFT_2023241.Endpoint.Services;
using FCW0VU_HFT_2023241.Logic;
using FCW0VU_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        ILocationLogic logic;
        IHubContext<SignalRHub> hub;

        public LocationController(ILocationLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Location> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Location Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Location value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("LocationCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Location value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("LocationUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var locToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("LocationDeleted", locToDelete);
        }
    }
}
