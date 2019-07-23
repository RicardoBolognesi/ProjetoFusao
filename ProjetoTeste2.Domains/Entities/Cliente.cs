using System.Collections.Generic;

namespace ProjetoTeste2.Domains.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            this.Enderecos = new HashSet<Endereco>();
            this.ClienteContatos = new HashSet<ClienteContato>();
        }
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string Fantasia { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string Obs { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<ClienteContato> ClienteContatos { get; set; }
    }
}
