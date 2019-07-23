namespace ProjetoTeste2.Domains.Entities
{
    public class ClienteContato : BaseEntity
    {
        public long ClienteContatoId { get; set; }
        public string NomeContato { get; set; }
        public string TelefoneContato { get; set; }
        public string EmailContato { get; set; }
        public string Cnpj { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
