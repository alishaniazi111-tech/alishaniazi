using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class groupstudentBL
    {
        public int GroupId { get; set; }
        public int studentId { get; set; }
        public string status { get; set; }
        public DateTime AssignmentDate { get; set; }
        public  groupstudentBL(int GroupId, int StudentId, string status, DateTime AssignmentDate)
        {
            this.GroupId = GroupId;
            this.studentId = StudentId;
            this.status = status;
            this.AssignmentDate = AssignmentDate;
        }

    }

}
