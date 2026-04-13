using projecta.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public class  groupBL
    {
        public int id { get; set; }
        public DateTime created_on { get; set; }
        public  groupBL (int id , DateTime created_on)
        {
            this.id = id;
            this.created_on = created_on;
        }
        GroupDL dl = new GroupDL();

        public DataTable GetGroups()
        {
            return dl.GetGroups();
        }

        public int CreateGroup()
        {
            return dl.CreateGroup();
        }
    }
}
