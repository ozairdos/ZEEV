using Gerenciador.Servico.Dominio.Modelo;
using Gerenciador.Servico.Servico;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gerenciador.Servico.WCF.Servico
{
    public class Servico : IServico
    {        
        public async Task<string> InserirTipoServico(TiposServicosModelo tipoServico)
        {            
            var serv = new GerenciadorServicos();
            return await serv.InserirTipoServico(tipoServico);
        }
    }
}
