using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject
{
   
    public class PeopleVO
    {   
        public string Name { get; set; }
        public string User { get; set; }
        public virtual DocumentVO Document { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }
        public virtual CompanyVO company { get; set; }

    }
}
