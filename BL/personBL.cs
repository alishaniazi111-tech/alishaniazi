using projecta.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.BL
{
    public enum GenderType
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public class PersonBL
    {
        public int Id { get; set; }           
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }


        PersonDL dl = new PersonDL();
      

        public int AddPerson()
        {
            return dl.AddPerson(this);
        }

       
        public void UpdatePerson()
        {
            dl.UpdatePerson(this);
        }

        public void DeletePerson()
        {
            dl.DeletePerson(this.Id);
        }
    }
}
