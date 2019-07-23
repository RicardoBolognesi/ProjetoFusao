using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using ProjetoTeste2.Domains.Dtos;

namespace ProjetoTeste2.Domains.Interfaces.Repository
{
    public interface IRequestInfoHelper
    {
        RequestInfo GetRequestInfo(IHttpConnectionFeature httpConnectionFeature);
        void BindRequestInfo(HttpContext httpContext, BaseResponseDto baseResponseDto);
    }
}
