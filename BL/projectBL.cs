using projecta.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace projecta.BL
{
    public class projectBL
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public projectBL(int Id, string description, string title)
        {
            this.Id = Id;
            this.description = description;
            this.title = title;
        }
        public projectBL()
        {
           
        }

        ProjectDL dl = new ProjectDL();

        public void AddProject(string title, string description)
        {
           
            projectBL p = new projectBL();
            p.title = title;
            p.description = description;

            
            dl.AddProject(p);
        }

        public DataTable GetAllProjects()
        {
            ProjectDL dl = new ProjectDL();
            return dl.GetProjects();
        }



    }

}

