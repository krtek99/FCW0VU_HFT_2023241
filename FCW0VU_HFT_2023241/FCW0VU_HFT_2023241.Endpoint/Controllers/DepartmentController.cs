using FCW0VU_HFT_2023241.Endpoint.Services;
using FCW0VU_HFT_2023241.Logic;
using FCW0VU_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic logic;
        IHubContext<SignalRHub> hub;

        public DepartmentController(IDepartmentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Department> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Department Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Department value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("DepartmentCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Department value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("DepartmentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var depToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("DepartmentDeleted", depToDelete);
        }
    }
}
