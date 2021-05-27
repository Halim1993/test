using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Model
{
    public class Employee
    {[Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string SystemName { get; set; }


        public string NetworkUserName { get; set; }
        public string macAddress { get; set; }

        public string NetworkName { get; set; }
    }
}
