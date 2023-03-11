using Microsoft.AspNetCore.Mvc;
using Overdrive.API.Data.ValueObject;
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
        public async Task<ActionResult<IEnumerable<PeopleVO>>> FindAll()
        {
            var peoples = await _repository.FindAll();
            return Ok(peoples);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<PeopleVO>> FindByName(string name)
        {
            var people = await _repository.FindByName(name);
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<PeopleVO>> CreateCompany([FromBody] PeopleVO vo)
        {
            if (vo == null) return BadRequest();
            var people = await _repository.CreatePeople(vo);
            return Ok(people);
        }

        [HttpPut]
        public async Task<ActionResult<PeopleVO>> UpdatePeople([FromBody] PeopleVO vo)
        {
            if (vo == null) return BadRequest();
            var people = await _repository.UpdatePeople(vo);
            return Ok(people);
        }

        [HttpPut("{idPeople}/{idCompany}")]
        public async Task<ActionResult<PeopleVO>> AddPeopleInCompany(long idPeople, long idCompany)
        {
            if (idPeople == null && idCompany == null) return BadRequest();
            var people = await _repository.AddPeopleInCompany(idPeople,idCompany);
            return Ok(people);
        }

    }
}
