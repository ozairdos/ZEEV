using AutoMapper;

namespace Gerenciador.Servico.Infra.Dados.Mapeamentos
{
    public class Perfil : Profile
    {
        public Perfil()
        {
            CreateMap<Dominio.Modelo.TiposServicosModelo, Dominio.Entidades.TiposServicos>()
                .ReverseMap();
            CreateMap<Dominio.Modelo.ServicosModelo, Dominio.Entidades.Servicos>()
                .ReverseMap();
        }
    }
}
