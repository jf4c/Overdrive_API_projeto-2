using Microsoft.AspNetCore.Mvc;
using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Model
{
    [Table("company")]
    public class Company : BaseEntity
    {
        [Column("cnpj")]
        [Required]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [Column("status")]
        [StringLength(10)]
        public Status? Status { get; set; }

        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? OpeningDate { get; set; }

        [Column("company_name")]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Column("trading_name")]
        [StringLength(100)]
        public string TradingName { get; set; }

        [Column("cnae")]
        [StringLength(7)]
        public string CNAE { get; set; }

        [Column("legal_nature")]
        [StringLength(30)]
        public string LegalNature { get; set; }

        public long? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }

        [Column("finance_capital")]
        public double? FinanceCapital { get; set; }

        public IEnumerable<People> peoples { get; set; }

    }
}
