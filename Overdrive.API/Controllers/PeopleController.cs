using Microsoft.AspNetCore.Mvc;
using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;
using Overdrive.API.Model;
using Overdrive.API.Repository;

namespace Overdrive.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {

        private IPeopleRepository _repository;

        public PeopleController(IPeopleRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(Repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleCreate>>> FindAll()
        {
            var peoples = await _repository.FindAll();
            return Ok(peoples);
        }

        [HttpGet("FindByName/{name}")]
        public async Task<ActionResult<PeopleCreate>> FindByName(string name)
        {
            var people = await _repository.FindByName(name);
            if (people == null) return NotFound();
            return Ok(people);
        }
        
        [HttpGet("FindByCPF/{cpf}")]
        public async Task<ActionResult<PeopleResponse>> FindByCpf(string cpf)
        {
            var people = await _repository.FindByCpf(cpf);
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<PeopleCreate>> CreatePeople([FromBody] PeopleCreate vo)
        {
            if (vo == null) return BadRequest();
            var people = await _repository.CreatePeople(vo);
            if (people == null) return BadRequest("ERR!: CPF igual encontrado");
            return Ok(people);
        }

        [HttpPut]
        public async Task<ActionResult<PeopleUpdate>> UpdatePeople([FromBody] PeopleUpdate vo)
        {
            if (vo == null) return BadRequest();
            if (vo.Id == null) return BadRequest("ERR!: Id não foi fornecido");
            var people = await _repository.UpdatePeople(vo);
            return Ok(people);
        }

        [HttpPut("ChangeStatus/{idPeople}")]
        public async Task<ActionResult<string>> ChangeStatus(long idPeople)
        {
            if (idPeople == null) return BadRequest();
            var status = await _repository.ChangePeopleStatus(idPeople);
            return Ok(status);  
        }

        [HttpPut("AddPeopleInCompany/{idPeople}/{idCompany}")]
        public async Task<ActionResult<CompanyAndPeople>> AddPeopleInCompany(long idPeople, long idCompany)
        {
            if (idPeople == null && idCompany == null) return BadRequest();
            var people = await _repository.AddPeopleInCompany(idPeople, idCompany);
            return Ok(people);
        }

        [HttpPut("RemovePeopleInCompany/{idPeople}")]
        public async Task<ActionResult<PeopleResponse>> RemovePeopleInCompany(long idPeople) 
        {
            if (idPeople == null) return BadRequest();
            var people = await _repository.RemovePeopleInCompany(idPeople);
            return Ok(people);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeople(long id)
        {
            var status = await _repository.DeletePeople(id);
            if(!status) return BadRequest();
            return Ok(status);
        }

    }
}
