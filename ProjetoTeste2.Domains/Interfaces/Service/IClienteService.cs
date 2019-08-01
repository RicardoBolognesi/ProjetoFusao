using System.Collections.Generic;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Domains.Interfaces.Service
{
    public interface IClienteService
    {
        void Add(Cliente cliente);
        void Del(Cliente cliente);
        IList<Cliente> GetAll();
        Cliente GetById(string id);
        void Upd(Cliente cliente);
    }
}
