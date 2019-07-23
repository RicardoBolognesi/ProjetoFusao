using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Interfaces;
using ProjetoTeste2.Domains.Interfaces.Repository;

namespace ProjetoTeste2.Domains
{
    public class RequestInfoHelper : IRequestInfoHelper

    {
        public RequestInfo GetRequestInfo(IHttpConnectionFeature httpConnectionFeature)
        {
            RequestInfo serverInfo = new RequestInfo();
            serverInfo.ConnectionId = httpConnectionFeature.ConnectionId;
            serverInfo.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
            serverInfo.LocalPort = httpConnectionFeature.LocalPort;
            serverInfo.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
            serverInfo.RemotePort = httpConnectionFeature.RemotePort;
            return serverInfo;
        }

        public void BindRequestInfo(HttpContext httpContext, BaseResponseDto baseResponseDto)
        {
            try
            {
                IHttpConnectionFeature httpConnectionFeature = httpContext.Features.Get<IHttpConnectionFeature>();
                baseResponseDto.ConnectionId = httpConnectionFeature.ConnectionId;
                baseResponseDto.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
                baseResponseDto.LocalPort = httpConnectionFeature.LocalPort;
                baseResponseDto.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
                baseResponseDto.RemotePort = httpConnectionFeature.RemotePort;
                baseResponseDto.RequestPath = httpContext.Request.Path.Value;
                baseResponseDto.SignedInTime = httpContext.Session.GetString("SignedInTime");
            }
            catch (Exception)
            {

            }
        }
    }
}
