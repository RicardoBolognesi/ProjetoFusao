using System;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Domains.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<EnderecoTipo> EnderecoTipoRepository { get; }
        //IRepository<Cliente> ClienteRepository { get; }

        bool SaveChanges();
    }
}
