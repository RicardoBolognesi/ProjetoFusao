using System;

namespace ProjetoTeste2.Domains.Entities
{
    public class SessionEntity
    {
        public string Id { get; set; }
        public Byte[] Value { get; set; }
        public DateTimeOffset ExpiresAtTime { get; set; }
        public Int64? SlidingExpirationInSeconds { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
    }
}
