using projecta.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class studentBL
    {
        public int Id { get; set; }
        public int RegistrationNo { get; set; }
        public studentBL(int id, int registrationNo)
        {
            this.Id = id;
            this.RegistrationNo = registrationNo;
        }
        StudentDL dl = new StudentDL();

        public DataTable GetFullStudents()
        {
            return dl.GetFullStudentData();
        }

        public void AddStudent(string fName, string lName, string contact, string email, string regNo, int gender)
        {
            dl.AddStudent(fName, lName, contact, email, regNo, gender);
        }

        public void UpdateStudent(int id, string fName, string lName, string contact, string email, string regNo, int gender)
        {
            dl.UpdateStudent(id, fName, lName, contact, email, regNo, gender);
        }

        public void DeleteStudent(int id)
        {
            dl.DeleteStudent(id);
        }
    }
}
