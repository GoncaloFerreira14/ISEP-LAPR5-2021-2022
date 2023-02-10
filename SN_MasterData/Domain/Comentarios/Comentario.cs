using System;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;


namespace SocialNetwork.Domain.Comentarios
{

    public class Comentario : Entity<ComentarioId>
    {
        public String PostId {get;private set;}
        public Jogador Jogador {get; private set;}
        public TextoComentario Texto {get; private set;}
        public DataComentario Data {get; private set;}

        public Comentario()
        {
        }

        public Comentario(String PostId, Jogador jog, TextoComentario texto, DataComentario data){
            if(PostId == null || jog == null || texto == null || data == null)
                throw new BusinessRuleValidationException("Parametros fornecidos inválidos");
            this.PostId = PostId;
            this.Jogador = jog;
            this.Texto = texto;
            this.Data = data;
        }
    }
}