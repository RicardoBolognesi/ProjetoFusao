using System.Collections.Generic;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Domains.Interfaces.Service
{
    public interface IEnderecoTipoService
    {
        void Adicionar(EnderecoTipo enderecoTipo);
        void Deletar(EnderecoTipo enderecoTipo);
        IList<EnderecoTipo> GetTodos();
        EnderecoTipo GetById(long id);
        void Atualizar(EnderecoTipo enderecoTipo);
    }
}
