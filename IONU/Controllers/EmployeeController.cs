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
        public async Task<ActionResult<Result>> AddEmployee([FromBody] Employee employee)
        {
            Result result = new Result();
            Employee employee1 = await _employee.Cheek(employee);
            if (employee1 == null)
            {

                await _employee.AddEmployee(employee);
                result.Massage = "تمت الاضافة بنجاح";
                result.statusCode = 201;

                return Ok(result);

            }
            else {
                result.Massage = "هذا الموظف موجود مسبقا";
                result.statusCode = 200;

                return Ok(result);

            }

           
        }
        [HttpPost("")]
        [Route("DeleteEmployee/{ID}")]
        public async Task<ActionResult<Result>> DeleteEmployee(int ID)
        { Employee employee =await _employee.GetEmployee(ID);
            Result result = new Result();
            if (employee != null) {
                await _employee.DeleteEmployee(ID);

                result.Massage = "تمت عملية الحدف بنجاح";
                result.statusCode = 200;
                return Ok(result);
            }
            result.Massage = "الموظف غير موجود";
            result.statusCode = 404;
            return NotFound(result);

        }
        [HttpGet]
        [Route("GetEmployee/{Id}")]
        public async Task<ActionResult<ResoultForEmployee>> GetEmployee(int Id)
        {
            string n = "موجود";
            string u = "غير موجود ";
            ResoultForEmployee result = new ResoultForEmployee();

            result.employee  = await _employee.GetEmployee(Id);
           

            if (result.employee != null)
            {

                result.massege = n;
                result.statsCode = 200;
                return Json(result);

            }

            result.massege = u;
            result.statsCode= 404;
            return Json(result);
          

        }
      
    }
}
