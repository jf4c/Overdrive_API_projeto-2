using Overdrive.API.Enum;
using Overdrive.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Overdrive.API.Data.ValueObject.Request
{

    public class PeopleCreate
    {
        public string Name { get; set; }
        public string User { get; set; }
        public string RG { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "ERR!: Tamanho maximo do CPF é de 11 caracteres")]
        [MinLength(11, ErrorMessage = "ERR!: Tamanho minimo do CPF é de 11 caracteres")]
        public string CPF { get; set; }
        public string Phone { get; set; }

    }
}
