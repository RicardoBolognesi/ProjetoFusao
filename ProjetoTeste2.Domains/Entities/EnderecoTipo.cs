using System.Collections.Generic;

namespace ProjetoTeste2.Domains.Entities
{
    public class EnderecoTipo : BaseEntity
    {
        public long EnderecoTipoId { get; set; }
        public string DescricaoTipo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
