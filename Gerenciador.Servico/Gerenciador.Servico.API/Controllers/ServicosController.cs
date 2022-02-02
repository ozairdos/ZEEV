using Gerenciador.Servico.Dominio.Modelo;
using Gerenciador.Servico.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gerenciador.Servico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly ILogger<GerenciadorServicos> _logger;

        public ServicosController(ILogger<GerenciadorServicos> logger)
        {
            _logger = logger;
        }

        [HttpPost("InserirTipoServico")]
        public async Task<string> InserirTipoServico(TiposServicosModelo tipoServico)
        {
            var serv = new GerenciadorServicos(_logger);
            return await serv.InserirTipoServico(tipoServico);
        }

        [HttpPost("InserirServico")]
        public async Task<string> InserirServico(ServicosModelo servico)
        {
            var serv = new GerenciadorServicos(_logger);
            return await serv.InserirServico(servico);
        }

        [HttpGet("ConsultarServicos")]
        public async Task<ListaConsultarServicos> ConsultarServicos()
        {
            var serv = new GerenciadorServicos(_logger);
            return await serv.ConsultarServicos();
        }

        [HttpGet("ConsultarServicosPorNome")]
        public async Task<ConsultarServicos> ConsultarServicosPorNome(string nome)
        {
            var serv = new GerenciadorServicos(_logger);
            return await serv.ConsultarServicosPorNome(nome);
        }

        [HttpGet("AlterarStatusServicosPorNome")]
        public async Task<string> AlterarStatusServicosPorNome(string nome, string status)
        {
            var serv = new GerenciadorServicos(_logger);
            return await serv.AlterarStatusServicosPorNome(nome, status);
        }
    }
}
