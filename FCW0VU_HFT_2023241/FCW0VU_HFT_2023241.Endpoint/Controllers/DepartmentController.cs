using FCW0VU_HFT_2023241.Logic;
using FCW0VU_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Endpoint.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentLogic logic;

        public DepartmentController(IDepartmentLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Department value)
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
