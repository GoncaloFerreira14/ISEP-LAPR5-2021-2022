using System.Collections.Generic;

namespace SocialNetwork.Domain.Jogadores
{
public static class JogadorMapper
{ 
    public static JogadorDto toDto(Jogador j)
    {
        return new JogadorDto{Id = j.Id.AsString(), Nome = j.Nome.Text, Email = j.Email.Endereco, Avatar = j.Avatar.Text,
                                     DataNascimento = j.DataNascimento.DataNascimento.ToString(), NumeroTelefone = j.NumeroTelefone.Numero, URLLinkedIn = j.URLLinkedIn.URL
                                     , URLFacebook = j.URLFacebook.URL, DescricaoBreve = j.DescricaoBreve.Text, Cidade = j.Cidade.Text, Pais = j.Pais.Text, ListaTags = j.conversaoTags(), EstadoHumor = j.EstadoHumor.EstadoHumor, ListaRelacoes =  j.getListaRelacoes()};
    }

    public static MostrarJogadorDto toMostrarDto(Jogador j)
    {
        return new MostrarJogadorDto{Id = j.Id.AsString(), Nome = j.Nome.Text, Email = j.Email.Endereco, Avatar = j.Avatar.Text,
                                     DataNascimento = j.DataNascimento.DataNascimento.ToString(), NumeroTelefone = j.NumeroTelefone.Numero, URLLinkedIn = j.URLLinkedIn.URL
                                     , URLFacebook = j.URLFacebook.URL, DescricaoBreve = j.DescricaoBreve.Text, Cidade = j.Cidade.Text, Pais = j.Pais.Text, ListaTags = j.conversaoTags(), EstadoHumor = j.EstadoHumor, ListaRelacoes =  j.getListaRelacoes()};
    }

      public static List<JogadorDto> toDtoList(List<Jogador> jogadores){
            return jogadores.ConvertAll<JogadorDto>(J => toDto(J));;
        }

        public static List<MostrarJogadorDto> toMostrarDtoList(List<Jogador> jogadores){
            return jogadores.ConvertAll<MostrarJogadorDto>(J => toMostrarDto(J));;
        }
}
}