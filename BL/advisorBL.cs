using projecta.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class advisorBL
    {
        public int Id { get; set; }
        public int Designation { get; set; } // Int for Lookup ID
        public decimal Salary { get; set; }

        public advisorBL(int id, int designation, decimal salary)
        {
            this.Id = id;
            this.Designation = designation;
            this.Salary = salary;
        }
        public advisorBL()
        {

        }

        AdvisorDL dl = new AdvisorDL();
        public void AddAdvisor(int id, string designation, decimal salary)
        {
           
            dl.AddAdvisor(this);
        }

        public DataTable GetAdvisors()
        {
            return dl.GetAdvisors();
        }
    }
}


      