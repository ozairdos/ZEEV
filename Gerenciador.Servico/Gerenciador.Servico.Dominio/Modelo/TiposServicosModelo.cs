using System;
using System.Runtime.Serialization;

namespace Gerenciador.Servico.Dominio.Modelo
{
    [DataContract]
    public class TiposServicosModelo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TipoServico { get; set; }
        [DataMember]
        public DateTime DataOperacao { get; set; }
        [DataMember]
        public int Status { get; set; }
    }
}
