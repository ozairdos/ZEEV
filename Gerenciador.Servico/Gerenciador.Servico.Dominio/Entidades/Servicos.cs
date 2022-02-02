using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador.Servico.Dominio.Entidades
{
    public class Servicos
    {
        [Key]
        public int Id { get; set; }
        public string Servico { get; set; }
        public string NomeServico { get; set; }
        public string Servidor { get; set; }
        [ForeignKey("TiposServicos")]
        public int TipoServicoId { get; set; }
        public DateTime DataOperacao { get; set; }
        public int Status { get; set; }
    }
}
