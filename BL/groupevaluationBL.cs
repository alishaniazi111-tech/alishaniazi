using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class groupevaluationBL
    {
        
        public int groupid { get; set; }
        public int evaluationid { get; set; }
        public float ObtainedMarks { get; set; }
         public DateTime EvaluationDate { get; set; }
        public  groupevaluationBL(int groupid, int evaluationid, float ObtainedMarks, DateTime EvaluationDate)
        {
            this.groupid = groupid;
            this.evaluationid = evaluationid;
            this.ObtainedMarks = ObtainedMarks;
            this.EvaluationDate = EvaluationDate;

        }
    }
}
