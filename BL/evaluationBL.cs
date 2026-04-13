using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
   public class evaluationBL
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public float totalMarks { get; set; }
        public float TotalWeightage { get; set; }

        public evaluationBL(int id, string Name, float Totalmarks, float Totalweightwage)
        {
           this.id = id;
            this.name = Name;
            this.TotalWeightage = Totalweightwage;
            this.totalMarks = Totalmarks;
        }
        
    }
}
