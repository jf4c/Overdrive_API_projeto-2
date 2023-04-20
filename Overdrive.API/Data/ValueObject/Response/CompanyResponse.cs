using Overdrive.API.Data.ValueObject.Response;
using Overdrive.API.Enum;
using Overdrive.API.Model;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{
    public class CompanyResponse
    {
        public long Id { get; set; }
        public string CNPJ { get; set; }
        public string Status { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string CNAE { get; set; }
        public string LegalNature { get; set; }
        public double FinanceCapital { get; set; }
        public virtual AddressResponse? Address { get; set; }


    }
}
