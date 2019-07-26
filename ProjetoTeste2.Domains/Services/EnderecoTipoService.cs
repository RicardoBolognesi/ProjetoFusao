using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;
using ProjetoTeste2.Domains.Utils;


namespace ProjetoTeste2.Domains.Services
{
    public class EnderecoTipoService : IEnderecoTipoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoTipoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Adicionar(EnderecoTipo enderecoTipo)
        {
            try
            {
                var corpo = "";


                _unitOfWork.EnderecoTipoRepository.Add(enderecoTipo);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Deletar(EnderecoTipo enderecoTipo)
        {
            try
            {
                _unitOfWork.EnderecoTipoRepository.Remove(enderecoTipo);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public EnderecoTipo GetById(long id)
        {

            EnderecoTipo enderecoTipo = new EnderecoTipo();
            enderecoTipo = _unitOfWork.EnderecoTipoRepository.Get(id);
            return enderecoTipo;

        }

        public IList<EnderecoTipo> GetTodos()
        {
            try
            {
                return _unitOfWork.EnderecoTipoRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Atualizar(EnderecoTipo enderecoTipo)
        {
            try
            {
                _unitOfWork.EnderecoTipoRepository.UpdateEntity(enderecoTipo);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EnvioEmail(string dest , string assunto, string msg)
        {
           return Utilities.EnviaEmail( dest,assunto,msg);
        }
    }
}
