using System;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    public class AlterarEstadoIntroducaoDto
    {
        public string Id { get; set; }

        public EstadosPedido EstadoPedido { get; set; }
    }
}