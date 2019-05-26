using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IUserRepository
    {
        DtoUser GetUser(int id);

        void AddUser(DtoUser user);
    }
}
