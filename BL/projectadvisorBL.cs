using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    internal class projectadvisorBL
    {
        public int AdvisorId { get; set; }
        public int ProjectId { get; set; }
        public string AdvisorRole { get; set; }
        public DateTime AssignmentDate { get; set; }
        public projectadvisorBL(int AdvisorId, int ProjectId, string AdvisorRole, DateTime AssignmentDate)
        {
            this.AdvisorId = AdvisorId;
            this.ProjectId = ProjectId;
            this.AdvisorRole = AdvisorRole;
            this.AssignmentDate = AssignmentDate;
        }
    }
}
