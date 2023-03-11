using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Overdrive.API.Model
{
    public class Document : BaseEntity
    {
        [Column("rg")]
        [StringLength(10)]
        public string RG { get; set; }

        [Column("cpf")]
        [StringLength(11)]
        public string CPF { get; set; }
    }
}
