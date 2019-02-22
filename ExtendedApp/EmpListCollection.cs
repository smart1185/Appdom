using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedApp
{
    public class EmpListCollection : MarshalByRefObject
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }        
        public string Phone { get; set; }

        public EmpListCollection()
        {

        }
    }
}
