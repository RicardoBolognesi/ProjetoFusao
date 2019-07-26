using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.App.Mappings.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<EnderecoTipo, EnderecoTipoDto>()
                .ReverseMap();
        }
    }
}
