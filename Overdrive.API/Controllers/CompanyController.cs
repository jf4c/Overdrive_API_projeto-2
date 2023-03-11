using Microsoft.AspNetCore.Mvc;
using Overdrive.API.Data.ValueObject;
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
        public async Task<ActionResult<IEnumerable<CompanyVO>>> FindAll()
        {
            var companies = await _repository.FindAll();
            return Ok(companies);
        }

        [HttpGet("{cnpj}")]
        public async Task<ActionResult<CompanyVO>> FindByCNPJ(string cnpj)
        {
            var company = await _repository.FindByCNPJ(cnpj);
            if(company == null) return NotFound();
            return Ok(company);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CompanyVO>> FindByName(string name)
        {
            var company = await _repository.FindByName(name);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<PeopleVO>>> FindAllPeopleInCompany(long idCompany)
        {
            var peoples = await _repository.FindAllPeopleInCompany(idCompany);
            return Ok(peoples);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyVO>> CreateCompany([FromBody] CompanyVO vo)
        {
            if (vo == null) return BadRequest();
            var company = await _repository.CreateCompany(vo);
            return Ok(company);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyVO>> UpdateCompany([FromBody] CompanyVO vo)
        {
            if (vo == null) return BadRequest();
            var company = await _repository.UpdateCompany(vo);
            return Ok(company);
        }


    }
}
