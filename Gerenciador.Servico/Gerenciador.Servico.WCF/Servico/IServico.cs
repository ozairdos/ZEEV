using CoreWCF;
using Gerenciador.Servico.Dominio.Modelo;
using Gerenciador.Servico.Servico;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gerenciador.Servico.WCF.Servico
{
    [ServiceContract]
    public interface IServico
    {       
        [OperationContract]
        Task<string> InserirTipoServico(TiposServicosModelo tipoServico);
    }
}
