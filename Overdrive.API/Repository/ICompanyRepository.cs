using Overdrive.API.Data.ValueObject;


namespace Overdrive.API.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyVO>> FindAll();
        Task<CompanyVO> FindByName(string name);
        Task<CompanyVO> FindByCNPJ(string cnpj);
        Task<CompanyVO> CreateCompany(CompanyVO vo);
        Task<CompanyVO> UpdateCompany(CompanyVO vo);
        Task<IEnumerable<PeopleVO>> FindAllPeopleInCompany(long idCompany);

    }
}
