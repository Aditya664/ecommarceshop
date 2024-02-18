namespace ecommarceshop.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
