using AutoMapper;
using MCE.CrossCutting.DependenciasInjetadas;
using MCE.CrossCutting.Mappings;
using MCE.Domain.Entities;
using MCE.Domain.Seguranca;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace MCE.Api
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
            ConfigureDependenciasDeRepositorios.ConfiguracaoDeDependenciaDeRepositorios(services);
            ConfigureDependenciasDeServicos.ConfiguracaoDeDependenciaDeServicos(services);

            var tokenConfiguration = new TokenConfiguracao();
            new ConfigureFromConfigurationOptions<TokenConfiguracao>
                                                (Configuration.GetSection("TokenConfiguration"))
                                                .Configure(tokenConfiguration);
            var configuracaoDaAssinatura = new ConfiguracaoDaAssinatura();

            services.AddSingleton(tokenConfiguration);

            services.AddSingleton(configuracaoDaAssinatura);

            //AutoMapper
            var config = new MapperConfiguration
            (
                cfg => 
                {
                    cfg.AddProfile(new DtoToEntidade());
                    cfg.AddProfile(new EntidadeToDto());
                }    
            );
            
            IMapper mapper  = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = configuracaoDaAssinatura.key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

                 // Valida a assinatura de um token recebido
                 paramsValidation.ValidateIssuerSigningKey = true;

                 // Verifica se um token recebido ainda é válido
                 paramsValidation.ValidateLifetime = true;

                 // Tempo de tolerância para a expiração de um token (utilizado
                 // caso haja problemas de sincronismo de horário entre diferentes
                 // computadores envolvidos no processo de comunicação)
                 paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ass Cristo Esperanca",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("https://www.google.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Maxwbs",
                        Email = "maxwbs@gmail.com",
                        Url = new Uri("https://www.google.com.br"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://www.google.com.br")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                     {
                         new OpenApiSecurityScheme {
                             Reference = new OpenApiReference {
                                 Id = "Bearer",
                                 Type = ReferenceType.SecurityScheme
                             }
                         }, new List<string>()
                     }
                 });
            });                     

            services.AddControllers().AddNewtonsoftJson();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ad Cristo Esperança");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(option => option.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
