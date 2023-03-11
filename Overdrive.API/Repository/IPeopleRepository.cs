using Overdrive.API.Data.ValueObject;

namespace Overdrive.API.Repository
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<PeopleVO>> FindAll();
        Task<PeopleVO> FindByName(string name);
        Task<PeopleVO> CreatePeople(PeopleVO vo);
        Task<PeopleVO> UpdatePeople(PeopleVO vo);
        Task<PeopleVO> AddPeopleInCompany(long idPeople,long idCompany);


    }
}
