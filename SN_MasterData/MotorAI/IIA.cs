using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.MotorAI
{
    public interface IIA
    {
        Task<String> boot(List<MostrarJogadorDto> utilizadores, List<RelacaoDto> relacionamentos);
        Task<String> adicionarUtilizador(JogadorDto dto);
        Task<String> adicionarRelacionamento(RelacaoDto dto);
        Task<String> caminhoMaisCurto(String orig, String dest);
        Task<String> tamanhoRede(MostrarJogadorDto dto, int n);
        Task<String> caminhoMaisSeguro(String orig, String dest,int limite);
       
    }
}