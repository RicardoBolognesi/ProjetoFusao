using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using ProjetoTeste2.Domain.Dtos;

namespace ProjetoTeste2.Domain.Interfaces
{
    public interface IRequestInfoHelper
    {
        RequestInfo GetRequestInfo(IHttpConnectionFeature httpConnectionFeature);
        void BindRequestInfo(HttpContext httpContext, BaseResponseDto baseResponseDto);
    }
}
