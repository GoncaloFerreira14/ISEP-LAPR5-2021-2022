using System;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Comentarios;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;

namespace SocialNetwork.Domain.Posts
{

    public class Post : Entity<PostId>, IAggregateRoot
    {
        public Jogador Jogador {get; private set;}
        public DataPost data {get; private set;}
        public TextoPost Texto {get; private set;}
        public LikePost LikePost {get; private set;}
        public DislikePost DislikePost {get; private set;}
        public List<Tag> TagsPost{get; private set;}
        public List<Comentario> Comentarios {get; private set;}

        public Post()
        {

        }

        public Post(Jogador jog, DataPost data, TextoPost texto, LikePost likePost, DislikePost dislikePost, List<Tag> tagsPost, List<Comentario> comentarios)
        {
            if(jog == null || data == null || texto == null || likePost == null || dislikePost == null || tagsPost == null || comentarios == null)
                throw new BusinessRuleValidationException("Parametros fornecidos invalidos");
            this.Id = new PostId(Guid.NewGuid().ToString());
            this.Jogador = jog;
            this.data = data;
            this.Texto = texto;
            this.LikePost = likePost;
            this.DislikePost = dislikePost;
            this.TagsPost = tagsPost;
            this.Comentarios = comentarios;
        }

        public List<String> conversaoTagsToStringPost(){
            List<String> lista = new List<string>();
            foreach (Tag t in this.TagsPost)
            {
                lista.Add(t.TagJM.Text);
            }
            return lista;
        }

        public List<String> conversaoComentariosToStringPost(){
            List<String> lista = new List<string>();
            foreach (Comentario c in this.Comentarios)
            {
                lista.Add(c.Texto.Texto);
            }
            return lista;
        }
    }
}