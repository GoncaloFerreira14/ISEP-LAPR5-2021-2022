using System;
using SocialNetwork.Domain.Shared;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Jogadores
{

    public class Jogador : Entity<JogadorId>, IAggregateRoot
    {
      
        public Texto Nome{get; private set;}
        public Email Email{get; private set;}
        public Texto Avatar{get; private set;}
        public Data  DataNascimento{get; private set;}
        public NumeroTelefone NumeroTelefone{get;private set;}
        public Url URLLinkedIn {get; private set;}
        public Url URLFacebook{get;private set;}
        public Texto DescricaoBreve{get; private set;}
        public Texto Cidade{get; private set;}
        public Texto Pais{get; private set;}
        public List<Tag> ListaTags{get; private set;}
        public EstadoEmocional EstadoHumor{get; private set;}

        public List<Relacao> ListaRelacoes{get; private set;}

        public Texto Password{get; private set;}

        public Jogador(){

        }

        //as tags por parametro pode se uma list
        public Jogador(string nome, string email, string avatar, string dataNascimento, string numeroTelefone, string urlLinkedin, string urlFacebook
                        , string descricao, string cidade, string pais, List<Tag> listTags, EstadosHumor estadoHumor, string pass)
        {
            this.Id = new JogadorId(Guid.NewGuid().ToString());
            this.Nome = new Texto(nome);
            this.Email = new Email(email);
            this.Avatar = new Texto(avatar);
            this.DataNascimento = new Data(dataNascimento);
            this.NumeroTelefone = new NumeroTelefone(numeroTelefone);
            this.URLLinkedIn = new Url(urlLinkedin);
            this.URLFacebook = new Url(urlFacebook);
            this.DescricaoBreve = new Texto(descricao);
            this.Cidade = new Texto(cidade);
            this.Pais = new Texto(pais);
            this.ListaTags = new List<Tag>(listTags);
            this.EstadoHumor = new EstadoEmocional(estadoHumor);
            this.ListaRelacoes = new List<Relacao>();
            this.Password = new Texto(pass);
        }

        public List<String> conversaoTags(){
            List<String> lista = new List<string>();
            foreach (Tag t in this.ListaTags)
            {
                lista.Add(t.TagJM.Text);
            }
            return lista;
        }

        public void addRelacao(Relacao r){
            this.ListaRelacoes.Add(r);
        }

         public void ChangeNome (String nome){
            this.Nome = new Texto(nome);
        }
         public void ChangeEmail (String email){
            this.Email = new Email(email);
        }
         public void ChangeAvatar (String avatar){
           this.Avatar =  new Texto(avatar);
        }
         public void ChangeData (String data){
            this.DataNascimento = new Data(data);
        }
        public void ChangeTelefone (String tele){
            this.NumeroTelefone = new NumeroTelefone(tele);
        }
        public void ChangeLinkedIn (String link){
            this.URLLinkedIn = new Url(link);
        }
        public void ChangeFacebook (String link){
            this.URLFacebook = new Url(link);
        }
         public void ChangeDesc (String desc){
            this.DescricaoBreve = new Texto(desc);
        }
         public void ChangeCidade (String desc){
            this.Cidade = new Texto(desc);
        }
         public void ChangePais (String desc){
            this.Pais = new Texto(desc);
        }

        public void ChangePassword (String pass){
            this.Password = new Texto(pass);
        }
        public void changeListaTags(List<Tag> lista){
            this.ListaTags = new List<Tag>(lista);
        }


        public List<String> getListaRelacoes(){
            List<String> lista = new List<string>();
            foreach (Relacao r in this.ListaRelacoes)
            {
                lista.Add(r.Id.AsString());
            }
            return lista;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Jogador j = (Jogador)obj;

            return this.Id.Equals(j.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()
                    * 3;
        }
    }

}