using Gerenciador.Servico.Dominio.Entidades;
using Gerenciador.Servico.Dominio.Modelo;
using Gerenciador.Servico.Infra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Gerenciador.Servico.Servico
{
    public class GerenciadorServicos : IGerenciadorServicos
    {
        private readonly ILogger _logger;

        public GerenciadorServicos(ILogger<GerenciadorServicos> logger)
        {
            _logger = logger;
        }

        public GerenciadorServicos()
        {           
        }

        public async Task<string> InserirTipoServico(TiposServicosModelo tipoServico)
        {            
            string retorno = string.Empty;

            try
            {
                await using (var db = new Contexto())
                {
                    var obj = new TiposServicos()
                    {
                        Id = tipoServico.Id,
                        TipoServico = tipoServico.TipoServico,
                        DataOperacao = tipoServico.DataOperacao,
                        Status = tipoServico.Status
                    };                     

                    var ret = db.TiposServicos.Add(obj);
                    db.SaveChanges();
                                        
                    retorno = ret.Entity.Id.ToString();

                    LogInformation("InserirTipoServico - Sucesso.");
                }
            }
            catch (System.Exception ex)
            {
                retorno = "InserirTipoServico - Erro - Detalhe: " + ex.Message;
                LogError("InserirTipoServico - Erro - Detalhe: " + ex.Message);
            }

            return retorno;
        }

        public async Task<string> InserirServico(ServicosModelo servico)
        {
            string retorno = string.Empty;

            try
            {
                await using (var db = new Contexto())
                {
                    var obj = new Servicos()
                    {
                        Id = servico.Id,
                        Servico = servico.Servico,
                        NomeServico = servico.NomeServico,
                        Servidor = servico.Servidor,
                        TipoServicoId = servico.TipoServicoId,
                        DataOperacao = servico.DataOperacao,
                        Status = servico.Status
                    };

                    var ret = db.Servicos.Add(obj);
                    db.SaveChanges();

                    retorno = ret.Entity.Id.ToString();

                    LogInformation("InserirServico - Sucesso.");
                }
            }
            catch (System.Exception ex)
            {
                retorno = "InserirServico - Erro - Detalhe: " + ex.Message;
                LogError("InserirServico - Erro - Detalhe: " + ex.Message);
            }

            return retorno;
        }

        public async Task<ListaConsultarServicos> ConsultarServicos()
        {
            //Verificar todos os serviços do windows
            //Filtrar com base na tabela Servicos

            ListaConsultarServicos listaConsultarServicos = new ListaConsultarServicos();

            try
            {
                List<Servicos> ret = new List<Servicos>();

                await using (var db = new Contexto())
                {
                    ret = db.Servicos.AsNoTracking().Where(x => x.Status == 15).Select(s => s).ToList();
                }

                foreach (var servico in ret)
                {
                    ServiceController sc = new ServiceController(servico.NomeServico);

                    ConsultarServicos consultarServicos = new ConsultarServicos();

                    consultarServicos = ConsultarStatusServicos("ConsultarServicos", sc, servico);

                    listaConsultarServicos.Add(consultarServicos);
                }

                LogInformation("ConsultarServicos - Sucesso.");
            }
            catch (System.Exception ex)
            {
                LogError("ConsultarServicos - Erro - Detalhe: " + ex.Message);
            }

            return listaConsultarServicos;            
        }

        public async Task<ConsultarServicos> ConsultarServicosPorNome(string nome)
        {
            //Verificar todos os serviços do windows
            //Filtrar por nome

            ConsultarServicos consultarServicos = new ConsultarServicos();

            try
            {
                Servicos ret = new Servicos();

                await using (var db = new Contexto())
                {
                    ret = db.Servicos.AsNoTracking().Where(x => x.NomeServico == nome && x.Status == 15).Select(s => s).FirstOrDefault();
                }

                if (ret == null)
                {
                    consultarServicos.Id = 0;
                    consultarServicos.Status = "Nao_Instalado";
                    consultarServicos.Nome = nome;

                    return consultarServicos;
                }

                ServiceController sc = new ServiceController(ret.NomeServico);

                consultarServicos = ConsultarStatusServicos("ConsultarServicosPorNome", sc, ret);

                LogInformation("ConsultarServicosPorNome - Sucesso.");
            }
            catch (System.Exception ex)
            {
                LogError("ConsultarServicosPorNome - Erro - Detalhe: " + ex.Message);
            }

            return consultarServicos;
        }

        public async Task<string> AlterarStatusServicosPorNome(string nome, string status)
        {
            //Verificar todos os serviços do windows
            //Filtrar por nome
            //Alterar status serviço (stop ou run)
                
            string retorno = string.Empty;

            try
            {
                Servicos ret = new Servicos();

                await using (var db = new Contexto())
                {
                    ret = db.Servicos.AsNoTracking().Where(x => x.NomeServico == nome && x.Status == 15).Select(s => s).FirstOrDefault();
                }

                if (ret == null)
                    return "Nenhum serviço localizado.";

                ServiceController sc = new ServiceController(ret.NomeServico);

                if (status == "run")
                {
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        retorno = "Sucesso: " + status;
                        LogInformation("AlterarStatusServicosPorNome: " + ret.NomeServico + " - " + status);
                    }
                }
                else if (status == "stop")
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                        retorno = "Sucesso: " + status;
                        LogInformation("AlterarStatusServicosPorNome: " + ret.NomeServico + " - " + retorno);
                    }
                }
                else
                {
                    retorno = "Status não localizado: " + status;
                    LogInformation("AlterarStatusServicosPorNome: " + ret.NomeServico + " - " + retorno);
                }
            }
            catch (System.Exception ex)
            {
                retorno = "Erro ao tentar " + status + " - Detalhe: " + ex.Message;
                LogError("AlterarStatusServicosPorNome - " + retorno);
            }

            return retorno;
        }

        private ConsultarServicos ConsultarStatusServicos(string nomeServico, ServiceController sc, Servicos servico)
        {
            ConsultarServicos consultarServicos = new ConsultarServicos();

            try
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    consultarServicos.Id = servico.Id;
                    consultarServicos.Status = "Running";
                    consultarServicos.Nome = servico.NomeServico;
                    LogInformation(nomeServico + ": " + servico.NomeServico + " - " + consultarServicos.Status);
                }
                else if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    consultarServicos.Id = servico.Id;
                    consultarServicos.Status = "Stopped";
                    consultarServicos.Nome = servico.NomeServico;
                    LogInformation(nomeServico + ": " + servico.NomeServico + " - " + consultarServicos.Status);
                }
            }
            catch (System.Exception ex)
            {
                consultarServicos.Id = servico.Id;
                consultarServicos.Status = "Nao_Instalado";
                consultarServicos.Nome = servico.NomeServico;
                LogError(nomeServico + " - Detalhe: " + ex.Message + " - " + servico.NomeServico + " - " + consultarServicos.Status);
            }

            return consultarServicos;
        }

        private void LogInformation(string log)
        {
            if (_logger != null)
                _logger.LogInformation(log);
        }

        private void LogError(string log)
        {
            if (_logger != null)
                _logger.LogError(log);
        }
    }
}
