using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Model
{
    [Table("people")]
    public class People : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("user")]
        [StringLength(100)]
        public string User { get; set; }

        [Column("rg")]
        [Required]
        [StringLength(10)]
        public string RG { get; set; }

        [Column("cpf")]
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Column("phone")]
        [StringLength(11)]
        public string Phone { get; set; }
        
        [Column("status")]
        [StringLength(10)]
        public Status? Status { get; set; }

        public long? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }

    }
}
