using ecommarceshop.Contexts;
using ecommarceshop.Interfaces;
using ecommarceshop.Models;

namespace ecommarceshop.Repositories
{
    public class UserRepository : RepositoryBase<Register>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
