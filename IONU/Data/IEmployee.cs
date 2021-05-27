using IONU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Data
{
   public interface IEmployee
    {
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);

        Task<List<Employee>> GetEmployees();

        Task UpdateEmployee(Employee transacation);

        Task DeleteEmployee(int id);

        Task<Employee> Cheek(Employee employee);
    }
}
