using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Infra.Context;

namespace ProjetoTeste2.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjetoTeste2DbContext context):base(context)
        {
            
        }
        public ProjetoTeste2DbContext ProjetoTeste2DbContext{get{return Context;}}
    }
}
