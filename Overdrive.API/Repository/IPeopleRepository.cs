using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Enum;

namespace Overdrive.API.Repository
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<PeopleResponse>> FindAll();
        Task<IEnumerable<PeopleResponse>> FindByName(string name);
        Task<PeopleCreate> CreatePeople(PeopleCreate vo);
        Task<PeopleUpdate> UpdatePeople(PeopleUpdate vo);
        Task<string> ChangePeopleStatus(long idPeople);
        Task<CompanyAndPeople> AddPeopleInCompany(long idPeople,long idCompany);
        Task<PeopleResponse> RemovePeopleInCompany(long idPeople);
        Task<bool> DeletePeople(long idPeople);
    }
}
