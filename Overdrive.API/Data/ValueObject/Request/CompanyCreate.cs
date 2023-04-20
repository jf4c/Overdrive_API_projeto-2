using Overdrive.API.Data.ValueObject.Response;
using Overdrive.API.Enum;
using Overdrive.API.Model;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{
    public class CompanyCreate
    {
        [Required]
        [MaxLength(14, ErrorMessage = "ERR!: Tamanho maximo do CNPJ é de 14 caracteres")]
        [MinLength(14, ErrorMessage = "ERR!: Tamanho minimo do CNPJ é de 14 caracteres")]
        public string CNPJ { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        [Required]
        [MaxLength(7, ErrorMessage = "ERR!: Tamanho maximo do CNAE é de 7 caracteres")]
        [MinLength(7, ErrorMessage = "ERR!: Tamanho minimo do CNAE é de 7 caracteres")]
        public string CNAE { get; set; }
        public string LegalNature { get; set; }
        public double FinanceCapital { get; set; }
        public virtual AddressResponse? Address { get; set; }


    }
}
