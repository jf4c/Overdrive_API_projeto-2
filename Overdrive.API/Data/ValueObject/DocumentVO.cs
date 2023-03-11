using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Overdrive.API.Data.ValueObject
{
    public class DocumentVO
    {
        public string RG { get; set; }
        public string CPF { get; set; }
    }
}
