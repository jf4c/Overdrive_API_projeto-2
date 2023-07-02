using Microsoft.AspNetCore.Mvc;
using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;
using Overdrive.API.Repository;

namespace Overdrive.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private ICompanyRepository _repository;

        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(Repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAndPeople>>> FindAll()
        {
            var companies = await _repository.FindAll();
            return Ok(companies);
        }

        [HttpGet("FindByCNPJ/{cnpj}")]
        public async Task<ActionResult<CompanyResponse>> FindByCNPJ(string cnpj)
        {
            var company = await _repository.FindByCNPJ(cnpj);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpGet("FindByName/{companyName}")]
        public async Task<ActionResult<CompanyResponse>> FindByName(string companyName)
        {
            var company = await _repository.FindByName(companyName);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpGet("FindAllPeopleInCompany/{idCompany}")]
        public async Task<ActionResult<CompanyAndPeople>> FindAllPeopleInCompany(long idCompany)
        {
            var peoples = await _repository.FindAllPeopleInCompany(idCompany);
            return Ok(peoples);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyCreate>> CreateCompany([FromBody] CompanyCreate vo)
        {
            if (vo == null) return BadRequest();
            var company = await _repository.CreateCompany(vo);
            if (company == null) return BadRequest("ERR!: CNPJ igual encontrado");
            return Ok(company);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyUpdate>> UpdateCompany([FromBody] CompanyUpdate vo)
        {
            if (vo == null) return BadRequest();
            if (vo.Id == null) return BadRequest("ERR!: Id não foi fornecido");
            var company = await _repository.UpdateCompany(vo);
            return Ok(company);
        }

        [HttpPut("ChangeStatus/{idCompany}")]
        public async Task<ActionResult<string>> ChangeStatus(long idCompany)
        {
            if (idCompany == null) return BadRequest();
            var status = await _repository.ChangeCompanyStatus(idCompany);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(long id)
        {
            var status = await _repository.DeleteCompany(id);
            if (!status) return BadRequest();
            return Ok(status);
        }


    }
}
