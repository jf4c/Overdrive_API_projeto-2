using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Overdrive.API.Data.ValueObject;
using Overdrive.API.Model;
using Overdrive.API.Model.context;

namespace Overdrive.API.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private ApiDbContext _context;
        private IMapper _mapper;


        public async Task<IEnumerable<PeopleVO>> FindAll()
        {
            List<People> peoples = await _context.Peoples.ToListAsync();
            return _mapper.Map<List<PeopleVO>>(peoples);
        }

        public async Task<PeopleVO> FindByName(string name)
        {
            People people = await _context.Peoples
                .Where(p => p.Name == name)
                .FirstOrDefaultAsync();
            return _mapper.Map<PeopleVO>(people);
        }

        public async Task<PeopleVO> CreatePeople(PeopleVO vo)
        {
            People people = _mapper.Map<People>(vo);
            _context.Peoples.Add(people);
            await _context.SaveChangesAsync();
            return _mapper.Map<PeopleVO>(people);
        }

        public async Task<PeopleVO> UpdatePeople(PeopleVO vo)
        {
            People people = _mapper.Map<People>(vo);
            _context.Peoples.Update(people);
            await _context.SaveChangesAsync();
            return _mapper.Map<PeopleVO>(people);
        }

        public async Task<PeopleVO> AddPeopleInCompany(long idPeople, long idCompany)
        {
            People people = await _context.Peoples
                .Where(p => p.Id == idPeople)
                .FirstOrDefaultAsync();
            Company company = await _context.Companies
                .Where(c => c.Id == idCompany)
                .FirstOrDefaultAsync();

            people.Company = company;
            _context.Peoples.Update(people);
            await _context.SaveChangesAsync();
            return _mapper.Map<PeopleVO>(people);
        }
    }
}
