using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SysWas.Repository.Context;


using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Repository.Repository.Madeiras;
using SysWas.Domain.Contratos.ICEP;
using SysWas.Repository.Repository.CEP;
using SysWas.Repository.Repository.Compras;
using SysWas.Domain.Contratos.ICompras;
using SysWas.Domain.Contratos.IEmpresas;
using SysWas.Repository.Repository.Empresas;
using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Repository.Repository.Financeiro;
using SysWas.Domain.Contratos.IFornecedores;
using SysWas.Repository.Repository.Fornecedores;
using SysWas.Domain.Contratos.IFretes;
using SysWas.Repository.Repository.Fretes;
using SysWas.Domain.Contratos.IInsumos;
using SysWas.Repository.Repository.Insumos;
using SysWas.Domain.Contratos.IUsuarios;
using SysWas.Repository.Repository.Usuarios;
using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Repository.Repository.Utilitarios;
using Microsoft.AspNetCore.Http;

namespace SysWas.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional:false, reloadOnChange:true);

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration.GetConnectionString("SysWasDB");
            services.AddDbContext<SysWasContext>(option => option.UseLazyLoadingProxies()
                                                    .UseMySql(connectionString, m =>
                                                    m.MigrationsAssembly("SysWas.Repository")));


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
            services.AddScoped<IListaInsumoRepository, ListaInsumoRepository>();
            services.AddScoped<IListaMadeiraRepository, ListaMadeiraRepository>();
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IControleSaldoRepository, ControleSaldoRepository>();
            services.AddScoped<ICustoRepository, CustoRepository>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();
            services.AddScoped<IDreRepository, DreRepository>();
            services.AddScoped<IListaBancoEmpresaRepository, ListaBancoEmpresaRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
            services.AddScoped<ITipoCustoRepository, TipoCustoRepository>();
            services.AddScoped<ITipoDespesaRepository, TipoDespesaRepository>();
            services.AddScoped<ITipoReceitaRepository, TipoReceitaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IListaBancariaRepository, ListaBancariaRepository>();
            services.AddScoped<IListaContatoRepository, ListaContatoRepository>();
            services.AddScoped<ITipoFornecedorRepository, TipoFornecedorRepository>();
            services.AddScoped<IFreteRepository, FreteRepository>();
            services.AddScoped<IItemTabelaFreteRepository, ItemTabelaFreteRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<ITabelaFreteRepository, TabelaFreteRepository>();
            services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IControleInsumoRepository, ControleInsumoRepository>();
            services.AddScoped<IEstoqueInsumoRepository, EstoqueInsumoRepository>();
            services.AddScoped<IInsumoRepository, InsumoRepository>();
            services.AddScoped<ITipoInsumoRepository, TipoInsumoRepository>();
            services.AddScoped<IControleMadeiraRepository, ControleMadeiraRepository>();
            services.AddScoped<IEspecieMadeiraRepository, EspecieMadeiraRepository>();
            services.AddScoped<IFardoRepository, FardoRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();
            services.AddScoped<IMadeiraRepository, MadeiraRepository>();
            services.AddScoped<ITipoMadeiraRepository, TipoMadeiraRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEstadoAprovacaoRepository, EstadoAprovacaoRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<ILogRegRepository, LogRegRepository>();
            services.AddScoped<ISecEditRepository, SecEditRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            // In production, the Angular files will be served fro/m this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                   // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
