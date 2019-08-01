using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;

namespace ProjetoTeste2.Domains.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Cliente cliente)
        {
            try
            {
                _unitOfWork.ClienteRepository.Add(cliente);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Del(Cliente cliente)
        {
            try
            {
                _unitOfWork.ClienteRepository.Remove(cliente);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<Cliente> GetAll()
        {
            try
            {
               return _unitOfWork.ClienteRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Cliente GetById(string id)
        {
            try
            {
                return _unitOfWork.ClienteRepository.SingleOrDefault(c=> c.Cnpj == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Upd(Cliente cliente)
        {
            try
            {
                _unitOfWork.ClienteRepository.UpdateEntity(cliente);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
