using IONU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Data
{
    public class ResoultForUser
    {

        public User user { get; set; }
        public int statusCode { get; set; }
        public string Massage { get; set; }

    }
}
