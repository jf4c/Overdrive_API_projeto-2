using AutoMapper;
using Overdrive.API.Data.ValueObject;
using Overdrive.API.Model.context;
using Overdrive.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Overdrive.API.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApiDbContext _context;
        private IMapper _mapper;
        
        public CompanyRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyVO>> FindAll()
        {
            List<Company> companies = await _context.Companies.ToListAsync();
            return _mapper.Map<List<CompanyVO>>(companies);
        }

        public async Task<CompanyVO> FindByCNPJ(string cnpj)
        {
            Company company = await _context.Companies
                .Where(c => c.CNPJ == cnpj)
                .FirstOrDefaultAsync();
            return _mapper.Map<CompanyVO>(company);
        }

        public async Task<CompanyVO> FindByName(string name)
        {
            Company company = await _context.Companies
                .Where(c => c.CompanyName == name)
                .FirstOrDefaultAsync();
            return _mapper.Map<CompanyVO>(company);
        }

        public async Task<CompanyVO> CreateCompany(CompanyVO vo)
        {
            Company company = _mapper.Map<Company>(vo);
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyVO>(company);
        }

        public async Task<CompanyVO> UpdateCompany(CompanyVO vo)
        {
            Company company = _mapper.Map<Company>(vo);
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyVO>(company);
        }

        public async Task<IEnumerable<PeopleVO>> FindAllPeopleInCompany(long idCompany)
        {
            List<People> peoples = await _context.Peoples
                .Where(p => p.Company.Id == idCompany)
                .ToListAsync();

            return _mapper.Map<List<PeopleVO>>(peoples);
        }
    }
}
