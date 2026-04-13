using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class groupprojectBL
    {
        public int ProjectId { get; set; }
        public int GroupId { get; set; }
        public DateTime AssignmentDate { get; set; }
       public  groupprojectBL(int ProjectId, int GroupId)
        {
            this.ProjectId = ProjectId;
            this.GroupId = GroupId;
        }

    }
}
