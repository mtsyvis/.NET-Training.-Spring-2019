namespace DAL.Interface.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();

        void Dispose();
    }
}
