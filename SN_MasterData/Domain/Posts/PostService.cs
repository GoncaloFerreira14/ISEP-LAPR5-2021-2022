using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Comentarios;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Domain.Posts
{
    public class PostService
    {
        private readonly ComentarioService comServ;
        private readonly JogadorService jogServ;

        private readonly string postsUrl = "https://posts-3dc01.herokuapp.com/api/";

        public PostService(ComentarioService comentServ, JogadorService jogServi)
        {
            this.comServ = comentServ;
            this.jogServ = jogServi;
        }


        public async Task<PostDto> AddAsync(CriarPostDto criarPostDto)
        {

            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.postsUrl);

            var res = await client.PostAsJsonAsync("posts", criarPostDto);

            if (!res.IsSuccessStatusCode)
            {
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var post = JsonConvert.DeserializeObject<PostDto>(await res.Content.ReadAsStringAsync());

            return post;

        }

        public async Task<PostDto> UpdateAsync(PostDto postDto)
        {

            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.postsUrl);

            var res = await client.PutAsJsonAsync("posts", postDto);

            if (!res.IsSuccessStatusCode)
            {
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var post = JsonConvert.DeserializeObject<PostDto>(await res.Content.ReadAsStringAsync());

            return post;
        }


        public async Task<List<PostDto>> GetAllAsync()
        {
            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(clientHandler);

            client.BaseAddress = new System.Uri(this.postsUrl);

            var res = await client.GetAsync("posts");

            if (!res.IsSuccessStatusCode)
            {
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var posts = JsonConvert.DeserializeObject<List<PostDto>>(await res.Content.ReadAsStringAsync());


            var listComentarios = await this.comServ.GetAllComentarios();

            var jogadores = await this.jogServ.GetAllAsync();


            if (posts != null)
            {
                posts.ForEach(post =>
                {
                    listComentarios.ForEach(comentario =>
                    {
                        if (post.id == comentario.PostId)
                        {
                            post.Comentarios.Add(comentario);
                        }
                        jogadores.ForEach(jogador =>
                        {
                            if (jogador.Id == post.JogadorId)
                            {
                                post.JogadorId = jogador.Nome;
                            }
                            if(comentario.JogadorId == jogador.Id){
                                comentario.JogadorId = jogador.Nome;
                            }
                        });
                    }
                    );
                }
                );
            }

            return posts;
        }

        public async Task<PostDto> GetByIdAsync(string id)
        {
            var clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri(this.postsUrl);

            var res = await client.GetAsync("posts/" + id);

            if (!res.IsSuccessStatusCode)
            {
                throw new ArgumentException(await res.Content.ReadAsStringAsync());
            }

            var posts = JsonConvert.DeserializeObject<PostDto>(await res.Content.ReadAsStringAsync());

            return posts;
        }

        /*
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _repo;

        public PostService(IUnitOfWork unitOfWork, IPostRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<PostDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<PostDto> listDto = list.ConvertAll<PostDto>(p => new PostDto
            {
                Id = p.Id.AsString(),
                JogadorId = p.Jogador.Id.AsString(),
                Data = p.data.dataPost.ToString(),
                Texto = p.Texto.Texto,
                LikePost = p.LikePost.ToString(),
                DislikePost = p.DislikePost.ToString(),
                TagsPost = p.conversaoTagsToStringPost(),
                Comentarios = p.conversaoComentariosToStringPost(),
            });

            return listDto;
        }

        public async Task<PostDto> GetByIdAsync(PostId id)
        {
            var p = await this._repo.GetByIdAsync(id);

            if(p == null)
                return null;

            return new PostDto
            {
                Id = p.Id.AsString(),
                JogadorId = p.Jogador.Id.AsString(),
                Data = p.data.dataPost.ToString(),
                Texto = p.Texto.Texto,
                LikePost = p.LikePost.ToString(),
                DislikePost = p.DislikePost.ToString(),
                TagsPost = p.conversaoTagsToStringPost(),
                Comentarios = p.conversaoComentariosToStringPost(),
            };
        }
        */
    }
}