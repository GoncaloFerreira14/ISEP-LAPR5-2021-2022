using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Infrastructure;
using SocialNetwork.Infrastructure.Categories;
using SocialNetwork.Infrastructure.Relacoes;
using SocialNetwork.Infrastructure.EstadosEmocionais;
using SocialNetwork.Infrastructure.PedidosIntroducao;
using SocialNetwork.Infrastructure.PedidosLigacao;
using SocialNetwork.Infrastructure.Products;
using SocialNetwork.Infrastructure.Families;
using SocialNetwork.Infrastructure.Jogadores;
using SocialNetwork.Infrastructure.Shared;
using SocialNetwork.Infrastructure.Tags;
using SocialNetwork.Infrastructure.Posts;
using SocialNetwork.Infrastructure.Comentarios;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Categories;
using SocialNetwork.Domain.Products;
using SocialNetwork.Domain.Families;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Posts;
using SocialNetwork.Domain.Comentarios;
using SocialNetwork.MotorAI;

namespace SocialNetwork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           /* services.AddDbContext<SocialNetworkDbContext>(opt =>
                opt.UseInMemoryDatabase("SocialNetworkDB")
                .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());*/
            /*services.AddDbContext<SocialNetworkDbContext>(opt =>
                                               opt.UseSqlServer("Password=RZsmUJ3wew==Xa5;Persist Security Info=True;User ID=sa;Initial Catalog=master;Data Source=vs449.dei.isep.ipp.pt").ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());*/
           /* services.AddDbContext<SocialNetworkDbContext>(opt =>
                                               opt.UseSqlServer(" Server=tcp:3dc01.database.windows.net,1433;Initial Catalog=bd-3dc01;Persist Security Info=False;User ID=salvalindas;Password=Afogafeias01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)).ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());*/
             services.AddDbContext<SocialNetworkDbContext>(opt =>
                                               opt.UseSqlServer(" Server=tcp:3dc-01server.database.windows.net,1433;Initial Catalog=3dc_01;Persist Security Info=False;User ID=salvalindas;Password=Afogafeias01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)).ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());                                 
            ConfigureMyServices(services);
            

            services.AddControllers().AddNewtonsoftJson();

            /* services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder => {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            }); */

            services.AddCors(option => option.AddPolicy( "AllowAll",builder => {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<CategoryService>();

            services.AddTransient<IJogadorRepository,JogadorRepository>();
            services.AddTransient<JogadorService>();

            services.AddTransient<ITagRepository,TagRepository>();
            services.AddTransient<TagService>();

            services.AddTransient<IEstadoEmocionalRepository,EstadoEmocionalRepository>();
            services.AddTransient<EstadoEmocionalService>();

            services.AddTransient<IRelacaoRepository,RelacaoRepository>();
            services.AddTransient<RelacaoService>();

            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ProductService>();

            services.AddTransient<IFamilyRepository,FamilyRepository>();
            services.AddTransient<FamilyService>();

            services.AddTransient<IPedidoIntroducaoRepository,PedidosIntroducaoRepository>();
            services.AddTransient<PedidoIntroducaoService>();

            services.AddTransient<IPedidoLigacaoRepository,PedidosLigacaoRepository>();
            services.AddTransient<PedidoLigacaoService>();

            services.AddTransient<IPostRepository,PostsRepository>();
            services.AddTransient<PostService>();
            
            services.AddTransient<ComentarioService>();

            services.AddTransient<MotorAi>();
        }
    }
}
