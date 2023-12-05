using FCW0VU_HFT_2023241.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IEmployeeLogic emplogic;
        IDepartmentLogic deplogic;

        public StatController(IEmployeeLogic emplogic, IDepartmentLogic deplogic)
        {
            this.emplogic = emplogic;
            this.deplogic = deplogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> GetDepartmentNameDetails()
        {
            return this.deplogic.GetDepartmentNameDetails();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetAvgSalaryPerDepartment()
        {
            return this.emplogic.GetAvgSalaryPerDepartment();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetEmployeesPerDepartment()
        {
            return this.emplogic.GetEmployeesPerDepartment();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> GetLargestSalaryPerDepartment()
        {
            return this.emplogic.GetLargestSalaryPerDepartment();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetTotalSalaryCostPerDepartment()
        {
            return this.emplogic.GetTotalSalaryCostPerDepartment();
        }
    }
}

