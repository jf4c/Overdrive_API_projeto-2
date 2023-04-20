using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{

    public class PeopleResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }
        public long? CompanyId { get; set; }
        public virtual CompanyResponse company { get; set; }

    }
}
