using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;

namespace Overdrive.API.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyResponse>> FindAll();
        Task<IEnumerable<CompanyResponse>> FindByName(string name);
        Task<CompanyResponse> FindByCNPJ(string cnpj);
        Task<CompanyCreate> CreateCompany(CompanyCreate vo);
        Task<CompanyUpdate> UpdateCompany(CompanyUpdate vo);
        Task<string> ChangeCompanyStatus(long idCompany);
        Task<CompanyAndPeople> FindAllPeopleInCompany(long idCompany);
        Task<bool> DeleteCompany(long idCompany);


    }
}
