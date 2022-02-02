using System.Collections.Generic;

namespace Gerenciador.Servico.Dominio.Modelo
{
    public class ConsultarServicos
    {        
        public int Id { get; set; }
        public string Status { get; set; }
        public string Nome { get; set; }
    }
    public class ListaConsultarServicos : List<ConsultarServicos>
    {
    }
}
