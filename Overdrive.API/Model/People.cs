using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Model
{
    [Table("people")]
    public class People : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("user")]
        public string User { get; set; }

        [ForeignKey("IdDocument")]
        public virtual Document Document { get; set; }
        
        [Column("phone")]
        public string Phone { get; set; }
        
        [Column("status")]
        public Status Status { get; set; }

        [ForeignKey("IdCompany")]
        public virtual Company Company { get; set; }

    }
}
