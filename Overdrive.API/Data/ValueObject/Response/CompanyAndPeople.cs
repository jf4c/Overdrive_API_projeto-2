using Overdrive.API.Data.ValueObject.Response;
using Overdrive.API.Enum;
using Overdrive.API.Model;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{
    public class CompanyAndPeople
    {
        public long Id { get; set; }
        public string CNPJ { get; set; }
        public Status? Status { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string CNAE { get; set; }
        public string LegalNature { get; set; }
        public long? AddressId { get; set; }
        public virtual AddressResponse? Address { get; set; }
        public double FinanceCapital { get; set; }
        public IEnumerable<PeopleCreate> peoples { get; set; }


    }
}
