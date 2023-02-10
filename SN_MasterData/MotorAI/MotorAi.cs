using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.MotorAI
{
    public class MotorAi: IIA
    
    {
        private const string JOGADOR_QUERY = "/jogador?i={0}&n={1}&t={2}";
        private const string RELACIONAMENTO_QUERY = "/relacaoj?i={0}&i1={1}&i2={2}&f1={3}";
         private const string CAMINHO_CURTO_QUERY = "/caminhoCurto?orig={0}&dest={1}";
        private const string TAMANHOREDE_QUERY = "/tamanhorede?i={0}&n={1}";
         private const string CAMINHO_SEGURO_QUERY = "/caminhoSeguro?i={0}&n={1}&l={2}";
        private readonly HttpClient _client;
        private readonly string _url;
        private readonly TagService _tagService;

        public MotorAi(TagService _tagService)
        {
            this._tagService = _tagService;
            _url = "https://vs-gate.dei.isep.ipp.pt:30782";
            _client = new HttpClient();
        }

        public async Task<string> boot(List<MostrarJogadorDto> utilizadores, List<RelacaoDto> relacionamentos)
        {
            StringBuilder sb = new StringBuilder();
            

            sb.Append("Inicializar base de conhecimento da IA:\n");
            foreach (var j in utilizadores)
            {
                sb.Append(j.Id).Append(": ");
                string resposta = await adicionarUtilizador(new JogadorDto{Id = j.Id, Nome = j.Nome, Email = j.Email, Avatar = j.Avatar,
                                     DataNascimento = j.DataNascimento, NumeroTelefone = j.NumeroTelefone, URLLinkedIn = j.URLLinkedIn
                                     , URLFacebook = j.URLFacebook, DescricaoBreve = j.DescricaoBreve, Cidade = j.Cidade, Pais = j.Pais, ListaTags = j.ListaTags, EstadoHumor = j.EstadoHumor.EstadoHumor, ListaRelacoes =  j.ListaRelacoes, Password = j.Password});
                sb.Append(resposta).Append("\n");
            }

            sb.Append("\n");
            foreach (var relacionamentoDto in relacionamentos)
            {
                sb.Append(relacionamentoDto.Id).Append(": ");
                string resposta = await adicionarRelacionamento(relacionamentoDto);
                sb.Append(resposta).Append("\n");
            }

            return sb.ToString();
        }

        public async Task<string> adicionarUtilizador(JogadorDto dto)
        {
            var relacoes = new List<string>();
            foreach (var interest in dto.ListaTags)
            {
                relacoes.Add(interest.ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            int tamanho = relacoes.Count;
            foreach (var tag in relacoes)
            {
                if (relacoes.IndexOf(tag) == tamanho-1)
                {
                    stringBuilder.Append(tag);
                }
                else
                {
                    stringBuilder.Append(tag + ",");
                }
            }
            Console.WriteLine(_url + String.Format(JOGADOR_QUERY, dto.Id, dto.Nome, stringBuilder.ToString()));
            return await _client.GetStringAsync(_url + String.Format(JOGADOR_QUERY, dto.Id, dto.Nome, stringBuilder.ToString()));
        }

        public async Task<string> adicionarRelacionamento(RelacaoDto dto)
        {
            return await _client.GetStringAsync(_url + String.Format(RELACIONAMENTO_QUERY, dto.Id.ToString(),
                dto.jogadorId.ToString(), dto.jogadorAmigoId.ToString(), dto.forcaLigacao));
        }

        public async Task<string> caminhoMaisCurto(String orig,String dest)
        {
            return await _client.GetStringAsync(_url + String.Format(CAMINHO_CURTO_QUERY, orig,
                dest));
        }

       

        public async Task<string> tamanhoRede(MostrarJogadorDto dto, int n){
            return await _client.GetStringAsync(_url + String.Format(TAMANHOREDE_QUERY,dto.Id,n));
        }

        public async Task<string> caminhoMaisSeguro(String orig,String dest,int limite)
        {
            return await _client.GetStringAsync(_url + String.Format(CAMINHO_SEGURO_QUERY, orig,
                dest,limite));
        }
    }
}