using projecta.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class  lookupBL
    {
      public int Id { get; set; }
        public string value { get; set; }
        public string category { get; set; }
       public lookupBL(int Id, string value, string category)
        {
            this.Id = Id;
            this.value = value;
            this.category = category;
        }
        LookupDL dl = new LookupDL();

        public DataTable GetAllLookups()
        {
            return dl.GetAllLookups();
        }

        public DataTable GetLookupByCategory(string category)
        {
            return dl.GetLookupByCategory(category);
        }

        public int GetLookupId(string category, string value)
        {
            return dl.GetLookupId(category, value);
        }

        // OPTIONAL (VERY USEFUL SHORTCUTS)

        public DataTable GetGender()
        {
            return dl.GetLookupByCategory("Gender");
        }

        public DataTable GetDesignation()
        {
            return dl.GetLookupByCategory("Designation");
        }
        public DataTable GetAdvisorRole()
        {
            return dl.GetLookupByCategory("AdvisorRole");
        }
    }
}
