using AutoMapper;
using Overdrive.API.Model.context;
using Overdrive.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;
using System.Data;

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

        public async Task<IEnumerable<CompanyResponse>> FindAll()
        {
            List<Company> companies = await _context.Companies
                .Include(c => c.Address)
                .Include(c => c.peoples)
                .ToListAsync();
            return _mapper.Map<List<CompanyResponse>>(companies);
        }

        public async Task<CompanyResponse> FindByCNPJ(string cnpj)
        {
            Company company = await _context.Companies
                .Where(c => c.CNPJ == cnpj)
                .Include(c => c.Address)
                .Include(c => c.peoples)
                .FirstOrDefaultAsync();
            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task<IEnumerable<CompanyResponse>> FindByName(string name)
        {
            List<Company> company = await _context.Companies
                .Where(c => c.CompanyName.Contains(name))
                .Include(c => c.Address)
                .Include(c => c.peoples)
                .ToListAsync();
            return _mapper.Map<IEnumerable<CompanyResponse>>(company);
        }

        public async Task<CompanyCreate> CreateCompany(CompanyCreate vo)
        {
            Company company = _mapper.Map<Company>(vo);
            
            var check = await _context.Companies
                .Where(c => c.CNPJ == company.CNPJ)
                .FirstOrDefaultAsync();

            var status =
                company.CompanyName != null &&
                company.TradingName != null &&
                company.CNAE != null &&
                company.LegalNature != null &&
                company.Address != null &&
                    company.Address.Cep != null &&
                    company.Address.Street != null &&
                    company.Address.Bairro != null &&
                    company.Address.Number != 0 &&
                    company.Address.City != null &&
                company.FinanceCapital != 0;

            if (status) company.Status = Status.Active;
            else company.Status = Status.Pending;

           
            if (company.Address.Cep == null)
            {
                company.AddressId = null;
                company.Address = null;
            }

            if (check == null)
            {
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return _mapper.Map<CompanyCreate>(company);
            }
            else
            {
                company = null;
                return _mapper.Map<CompanyCreate>(company);

            }


        }

        public async Task<CompanyUpdate> UpdateCompany(CompanyUpdate vo)
        {
            Company company = _mapper.Map<Company>(vo);
            Company companyDB = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Id == company.Id)
                .FirstOrDefaultAsync();


            company.CNPJ = companyDB.CNPJ;
            company.OpeningDate = companyDB.OpeningDate;

            var status =
                company.CompanyName != null &&
                company.TradingName != null &&
                company.CNAE != null &&
                company.LegalNature != null &&
                company.Address != null &&
                    company.Address.Cep != null &&
                    company.Address.Street != null &&
                    company.Address.Bairro != null &&
                    company.Address.Number != null &&
                    company.Address.City != null &&
                company.FinanceCapital != null;

            if (status) company.Status = Status.Active;
            else company.Status = Status.Pending;

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyUpdate>(company);
        }

        public async Task<CompanyAndPeople> FindAllPeopleInCompany(long idCompany)
        {
            List<People> peoples = await _context.Peoples
                .Where(p => p.Company.Id == idCompany)
                .ToListAsync();

            var company = await _context.Companies
                .Where(c => c.Id == idCompany)
                .FirstOrDefaultAsync();
            company.peoples = peoples;

            return _mapper.Map<CompanyAndPeople>(company);
        }

        public async Task<string> ChangeCompanyStatus(long idCompany)
        {
            Company company = await _context.Companies
                .Where(c => c.Id == idCompany)
                .FirstOrDefaultAsync();

            People people = await _context.Peoples
                .Where(p => p.CompanyId == idCompany)
                .FirstOrDefaultAsync();

            if (company.Status != Status.Pending)
            {
                var status = company.Status == Status.Active;
                if (status)
                {
                    company.Status = Status.Inactive;
                    if(people != null)
                    {
                        people.CompanyId = null;
                        people.Company = null;
                    }
                }
                else
                {
                    company.Status = Status.Active;
                }
                _context.Companies.Update(company);
                _context.SaveChanges();
                return _mapper.Map<string>(company.Status);
            }
            else
            {
                return _mapper.Map<string>(company.Status);
            }
        }

        public async Task<bool> DeleteCompany(long idCompany)
        {
            try
            {
                Company company = await _context.Companies
                    .Where(c => c.Id == idCompany)
                    .Include(c => c.Address)
                    .FirstOrDefaultAsync();
                var address = company.Address;
                var addrDb = await _context.Companies
                    .Where(c => c.Address.Id == address.Id)
                    .ToListAsync();
                if (company == null) return false;
                
                _context.Companies.Remove(company);
               
                if (address != null && addrDb.Count == 1) _context.Addresses.Remove(address);
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
