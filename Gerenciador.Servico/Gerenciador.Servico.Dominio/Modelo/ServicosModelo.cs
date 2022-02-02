using System;

namespace Gerenciador.Servico.Dominio.Modelo
{
    public class ServicosModelo
    {
        public int Id { get; set; }
        public string Servico { get; set; }
        public string NomeServico { get; set; }
        public string Servidor { get; set; }
        public int TipoServicoId { get; set; }
        public DateTime DataOperacao { get; set; }
        public int Status { get; set; }
    }
}
