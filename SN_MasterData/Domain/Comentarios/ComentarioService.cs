using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.Comentarios
{
    public class ComentarioService
    {
        private readonly string apiUrl = "https://posts-3dc01.herokuapp.com/api/";

        public ComentarioService(){

        }

        public async Task<ComentarioDto> addAsync(ComentarioDto dto)
        {
            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.apiUrl);

            var res = await client.PostAsJsonAsync("comentarios", dto);

            if (!res.IsSuccessStatusCode){
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var comentario = JsonConvert.DeserializeObject<ComentarioDto>(await res.Content.ReadAsStringAsync());

            return comentario;
        }

        public async Task<List<ComentarioDto>> GetAllComentarios(){
            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
            
            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.apiUrl);

            var res = await client.GetAsync("comentarios");

            if (!res.IsSuccessStatusCode){
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var comentarios = JsonConvert.DeserializeObject<List<ComentarioDto>>(await res.Content.ReadAsStringAsync());

            return comentarios;
        }

        public async Task<List<ComentarioDto>> GetComentariosByPostIdAsync(String postId)
        {
            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
            
            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.apiUrl);

            var res = await client.GetAsync("comentarios/" + postId);

            if (!res.IsSuccessStatusCode){
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var comentarios = JsonConvert.DeserializeObject<List<ComentarioDto>>(await res.Content.ReadAsStringAsync());

            return comentarios;
        }
    }
}