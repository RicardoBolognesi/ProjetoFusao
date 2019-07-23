using System.Collections.Generic;

namespace ProjetoTeste2.Domains.Entities
{
    public class Endereco : BaseEntity
    {

        public long EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public long Numero { get; set; }
        public string Compl { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Cnpj { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
