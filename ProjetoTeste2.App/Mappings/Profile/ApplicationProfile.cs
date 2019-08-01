using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Service;
using ProjetoTeste2.Domains.Services;

namespace ProjetoTeste2.App.Mappings.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<EnderecoTipo, EnderecoTipoDto>().ReverseMap();
            CreateMap<IUserService, UserService>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
