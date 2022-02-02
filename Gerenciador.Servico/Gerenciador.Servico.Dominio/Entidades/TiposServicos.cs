using System;
using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Servico.Dominio.Entidades
{
    public class TiposServicos
    {
        [Key]
        public int Id { get; set; }
        public string TipoServico { get; set; }
        public DateTime DataOperacao { get; set; }
        public int Status { get; set; }
    }
}
