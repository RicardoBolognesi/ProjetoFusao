using System;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Infra.Context;

namespace ProjetoTeste2.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variáveis
        protected readonly ProjetoTeste2DbContext Context;
        private BaseRepository<User> _userRepository = null;

        private BaseRepository<EnderecoTipo> _enderecoTipoRepository = null;
        //private BaseRepository<Cliente> _clienteRepository = null;

        #endregion

        public UnitOfWork(ProjetoTeste2DbContext context)
        {
            Context = context;
        }


        #region Propriedades
        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new BaseRepository<User>(Context);
                }
                return _userRepository;
            }
        }
        public IRepository<EnderecoTipo> EnderecoTipoRepository {
            get
            {
                if (_enderecoTipoRepository == null)
                {
                    _enderecoTipoRepository = new BaseRepository<EnderecoTipo>(Context);
                }

                return _enderecoTipoRepository;
            }
        }


        //public IRepository<Cliente> ClienteRepository
        //{
        //    get
        //    {
        //        if (_clienteRepository == null)
        //        {
        //            _clienteRepository = new BaseRepository<Cliente>(Context);
        //        }
        //        return _clienteRepository;
        //    }
        //}
        #endregion

        public bool SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }


        #region IDisposable Support  
        private bool _disposedValue = false; // To detect redundant calls  




        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                //dispose managed state (managed objects).  
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.  
            // set large fields to null.  

            _disposedValue = true;
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.  
        // ~UnitOfWork() {  
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
        //   Dispose(false);  
        // }  

        // This code added to correctly implement the disposable pattern.  
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.  
            // GC.SuppressFinalize(this);  
        }
        #endregion

    }
}
