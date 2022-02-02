using Gerenciador.Servico.Dominio.Modelo;
using System.Threading.Tasks;

namespace Gerenciador.Servico.Servico
{
    public interface IGerenciadorServicos
    {
        Task<string> InserirTipoServico(TiposServicosModelo tipoServico);

        Task<string> InserirServico(ServicosModelo servico);

        Task<ListaConsultarServicos> ConsultarServicos();

        Task<ConsultarServicos> ConsultarServicosPorNome(string nome);

        Task<string> AlterarStatusServicosPorNome(string nome, string status);
    }
}
