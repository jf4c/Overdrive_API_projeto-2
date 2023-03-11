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
        public Status Status { get; set; }

        [Column("opening_date")]
        public DateTime OpeningDate { get; set; }

        [Column("company_name")]
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        
        [Column("trading_name")]
        [StringLength(100)]
        public string TradingName { get; set; }
       
        [Column("cnae")]
        [Required]
        [StringLength(7)]
        public string CNAE { get; set; }

        [Column("legal_nature")]
        [StringLength(30)]
        public string LegalNature { get; set; }
        
        [ForeignKey("IdAddress")]
        public virtual Address Address { get; set; }

        [Column("cinance_capital")]
        public double FinanceCapital { get; set; }

        public IEnumerable<People> peoples { get; set; }

    }
}
