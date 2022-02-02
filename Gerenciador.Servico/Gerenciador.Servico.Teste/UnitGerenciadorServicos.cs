using Gerenciador.Servico.Dominio.Modelo;
using NUnit.Framework;
using System;

namespace Gerenciador.Servico.Teste
{
    public class UnitGerenciadorServicos
    {
        [Test]
        public void InserirTipoServico()
        {
            TiposServicosModelo tiposServicosModelo = new TiposServicosModelo();
            Servico.GerenciadorServicos gerenciadorServicos = new Servico.GerenciadorServicos();

            tiposServicosModelo.Id = 0;
            tiposServicosModelo.TipoServico = "Windows Service";
            tiposServicosModelo.DataOperacao = DateTime.Now;
            tiposServicosModelo.Status = 15;

            gerenciadorServicos.InserirTipoServico(tiposServicosModelo).Wait();
        }

        [Test]
        public void InserirServico()
        {
            ServicosModelo servicosModelo = new ServicosModelo();
            Servico.GerenciadorServicos gerenciadorServicos = new Servico.GerenciadorServicos();

            servicosModelo.Id = 0;
            servicosModelo.Servico = "XblAuthManager";
            servicosModelo.NomeServico = "XblAuthManager";
            servicosModelo.Servidor = "NOME_SERVIDOR";
            servicosModelo.TipoServicoId = 1;
            servicosModelo.DataOperacao = DateTime.Now;
            servicosModelo.Status = 15;

            gerenciadorServicos.InserirServico(servicosModelo).Wait();
        }

        [Test]
        public void ConsultarServicos()
        {
            Servico.GerenciadorServicos gerenciadorServicos = new Servico.GerenciadorServicos();
            gerenciadorServicos.ConsultarServicos().Wait();
        }

        [Test]
        public void ConsultarServicosPorNome()
        {
            Servico.GerenciadorServicos gerenciadorServicos = new Servico.GerenciadorServicos();
            gerenciadorServicos .ConsultarServicosPorNome("NOME_SERVICO_WINDOWS").Wait();
        }

        [Test]
        public void AlterarStatusServicosPorNome()
        {
            Servico.GerenciadorServicos gerenciadorServicos = new Servico.GerenciadorServicos();
            gerenciadorServicos .AlterarStatusServicosPorNome("NOME_SERVICO_WINDOWS", "run").Wait();
        }
    }
}
