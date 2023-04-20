using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Model
{
    [Table("address")]
    public class Address : BaseEntity
    {
        [Column("cep")]
        [StringLength(8)]
        public string Cep { get; set; }

        [Column("street")]
        [StringLength(100)]
        public string Street { get; set; }

        [Column("bairro")]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Column("number")]
        public int? Number { get; set; }

        [Column("city")]
        [StringLength(30)]
        public string City { get; set; }
    }
}