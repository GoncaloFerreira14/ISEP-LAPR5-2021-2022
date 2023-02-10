using System;
using SocialNetwork.Domain.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Domain.Relacoes
{   
    public class Relacao : Entity<RelacaoId>, IAggregateRoot
    {
        public ForcaRelacao forcaRelacao{get; set;}  //CALCULADA PELO SISTEMA
        public ForcaLigacao forcaLigacao{get; set;} //Introduzida pelo Utilizador
        public DataRelacao DataRelacao{get; private set;}

        public List<Tag> ListaTags{get; set;}

        public Jogador jogadorAmigo{get; private set;}

        public Jogador jogador{get; private set;}



        public Relacao(){
        }

        public Relacao(int forca,List<Tag> tags, Jogador amigo, Jogador jog){
             this.Id = new RelacaoId(Guid.NewGuid().ToString());
             this.DataRelacao = new DataRelacao(DateTime.Now);
             this.forcaLigacao = new ForcaLigacao(forca);
             this.ListaTags = new List<Tag>(tags);
             this.jogadorAmigo = amigo;
             this.jogador = jog;
             this.forcaRelacao = new ForcaRelacao(0);
        }

        public List<String> conversaoTagsRelacao(){
            List<String> lista = new List<string>();
            foreach (Tag t in this.ListaTags)
            {
                lista.Add(t.TagJM.Text);
            }
            return lista;
        }


        public void changeForcaLigacao(int forca){
            this.forcaLigacao = new ForcaLigacao(forca);
        }

        public void changeListaTags(List<Tag> lista){
            this.ListaTags = new List<Tag>(lista);
        }

        public void changeData(){
            this.DataRelacao = new DataRelacao(DateTime.Now);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Relacao e = (Relacao)obj;

            return this.Id.Equals(e.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()
                    * 3;
        }

    }
        
}