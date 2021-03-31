using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCL.Api.Models
{
    public class Contact
    {
        /// <summary>
        /// This is unique id of the employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// This is name of the employee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is email id of the employee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// This is mobile number of the employee
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// This is address of the employee
        /// </summary>
        public string Address { get; set; }
    }
}
