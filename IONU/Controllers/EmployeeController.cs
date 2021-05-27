using IONU.Data;
using IONU.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        public IEmployee _employee { get; }

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            List<Employee> employees = await _employee.GetEmployees();

            if (employees != null)
            {

                return Json(employees);
            }
            else {

                return NotFound();
            
            }
           
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task AddEmployee([FromBody] Employee employee)
        {
            Employee employee1 = await _employee.Cheek(employee);
            if (employee1 == null) {

              await  _employee.AddEmployee(employee);
            
            }

           
        }
        [HttpPost]
        [Route("DeleteEmployee")]
        public void DeleteEmployee([FromBody] Employee employee)
        {
            _employee.DeleteEmployee(employee.Id);

        }
        [HttpGet]
        [Route("GetTransaction/{Id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int Id)
        {
            Employee employee = await _employee.GetEmployee(Id);

            return Json(employee);
        }
      
    }
}
