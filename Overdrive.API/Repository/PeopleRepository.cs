using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;
using Overdrive.API.Model;
using Overdrive.API.Model.context;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Overdrive.API.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private ApiDbContext _context;
        private IMapper _mapper;

        public PeopleRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PeopleResponse>> FindAll()
        {
            List<People> peoples = await _context.Peoples
                .Include(p => p.Company)
                .Include(p => p.Company.Address)
                .ToListAsync();
            return _mapper.Map<List<PeopleResponse>>(peoples);
        }

        public async Task<IEnumerable<PeopleResponse>> FindByName(string name)
        {
            List<People> people = await _context.Peoples
                .Where(p => p.Name.Contains(name))
                .Include(p => p.Company)
                .ThenInclude(c => c.Address)
                .ToListAsync();
            return _mapper.Map<IEnumerable<PeopleResponse>>(people);
        }

        public async Task<PeopleResponse> FindByCpf(string cpf)
        {
            People people = await _context.Peoples
                .Where(p => p.CPF == cpf)
                .Include(p => p.Company)
                .FirstOrDefaultAsync();
            return _mapper.Map<PeopleResponse>(people);
        }

        public async Task<PeopleCreate> CreatePeople(PeopleCreate vo)
        {
            People people = _mapper.Map<People>(vo);
            var check = await _context.Peoples
                .Where(p => p.CPF == people.CPF)
                .FirstOrDefaultAsync();

            var status =
                people.Name != null &&
                people.User != null &&
                people.RG != null &&
                people.CPF != null &&
                people.Phone != null;

            if (status) people.Status = Status.Active;
            else people.Status = Status.Pending;

            if(check == null)
            {
                _context.Peoples.Add(people);
                await _context.SaveChangesAsync();
                return _mapper.Map<PeopleCreate>(people);
            }
            else
            {
                people = null;
                return _mapper.Map<PeopleCreate>(people);

            }

        }

        public async Task<PeopleUpdate> UpdatePeople(PeopleUpdate vo)
        {
            People people = _mapper.Map<People>(vo);
            People peopleDB = await _context.Peoples
                .AsNoTracking()
                .Where(p => p.Id == people.Id)
                .FirstOrDefaultAsync();

            people.CPF = peopleDB.CPF;
            people.RG = peopleDB.RG;
            people.CompanyId = peopleDB.CompanyId;
            people.Company = peopleDB.Company;

            var status =
                people.Name != null &&
                people.User != null &&
                people.RG != null &&
                people.CPF != null &&
                people.Phone != null;

            if (status) people.Status = Status.Active;
            else people.Status = Status.Pending;
            

            _context.Peoples.Update(people);
            await _context.SaveChangesAsync();
            return _mapper.Map<PeopleUpdate>(people);
        }

        public async Task<string> ChangePeopleStatus(long idPeople)
        {
            People people = await _context.Peoples
                .Where(p => p.Id == idPeople)
                .FirstOrDefaultAsync();

            if(people.Status != Status.Pending)
            {
                var status = people.Status == Status.Active;
                if (status)
                {
                    people.Status = Status.Inactive;
                    people.CompanyId = null;
                    people.Company = null;
                }
                else
                {
                    people.Status = Status.Active;
                }
                _context.Peoples.Update(people);
                _context.SaveChanges();
                return _mapper.Map<string>(people.Status);
            }
            else
            {
                return _mapper.Map<string>(people.Status);
            }
        }

        public async Task<CompanyAndPeople> AddPeopleInCompany(long idPeople, long idCompany)
        {
            People people = await _context.Peoples
                .Where(p => p.Id == idPeople)
                .FirstOrDefaultAsync();
            Company company = await _context.Companies
                .Where(c => c.Id == idCompany)
                .Include(c => c.Address)
                .FirstOrDefaultAsync();

            if (people.Status == Status.Active && company.Status == Status.Active)
            {
                people.Company = company;
                _context.Peoples.Update(people);
                await _context.SaveChangesAsync();
            }
            
            return _mapper.Map<CompanyAndPeople>(company);
        }

        public async Task<PeopleResponse> RemovePeopleInCompany(long idPeople)
        {
            People people = await _context.Peoples
                .Where(p => p.Id == idPeople)
                .FirstOrDefaultAsync();

            if (people != null)
            {
                people.CompanyId = null;
                people.Company = null;
                _context.Peoples.Update(people);
            }
               
                await _context.SaveChangesAsync();
          

            return _mapper.Map<PeopleResponse>(people);
        }

        public async Task<bool> DeletePeople(long idPeople)
        {
            try
            {
                People people = await _context.Peoples
                    .Where(p => p.Id == idPeople)
                    .FirstOrDefaultAsync();
                if(people == null) return false;
                _context.Peoples.Remove(people);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
