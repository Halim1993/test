using IONU.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Data
{
    public class MookEmployee : IEmployee
    {
        private readonly ApplicationDbcontext _dbcontext;

        public MookEmployee(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddEmployee(Employee employee)
        {
            try
            {
               

           _dbcontext.Employees.Add(employee);
               await     _dbcontext.SaveChangesAsync();
             
            

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee> Cheek(Employee employee) {

            Employee employee1 = await _dbcontext.Employees.FirstOrDefaultAsync(x => x.EmployeeName == employee.EmployeeName);
            return employee1;

        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                Employee employee = await _dbcontext.Employees.FindAsync(id);

                if (employee != null)
                {

                    _dbcontext.Employees.Remove(employee);
                    await _dbcontext.SaveChangesAsync();

                }

            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {

                List<Employee> employees = await _dbcontext.Employees.ToListAsync();
                return employees;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                Employee employee = await _dbcontext.Employees.FindAsync(id);

       
                    return employee;
               

            

            }
            
            catch (Exception)
            {

                throw;
            }
           
        }

        public  async Task UpdateEmployee(Employee employee)
        {

            Employee employee1 = await _dbcontext.Employees.FindAsync(employee.Id);


            if (employee1!=null) {

                _dbcontext.Employees.Update(employee);

                await _dbcontext.SaveChangesAsync();
            
            }
            
        }
    }
}
