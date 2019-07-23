namespace ProjetoTeste2.Domains.Dtos
{
    public class BaseResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }
        public string ConnectionId { get; set; }
        public string RemoteIpAddress { get; set; }
        public string LocalIpAddress { get; set; }
        public int RemotePort { get; set; }
        public int LocalPort { get; set; }
        public string RequestPath { get; set; }
        public string SignedInTime { get; set; }
    }
}
