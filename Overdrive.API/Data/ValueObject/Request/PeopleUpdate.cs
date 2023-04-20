using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{

    public class PeopleUpdate
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Phone { get; set; }

    }
}
