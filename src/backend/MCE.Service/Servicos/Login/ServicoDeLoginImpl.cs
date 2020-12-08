using MCE.Domain.Interfaces.Servicos.Login;
using MCE.Domain.Interfaces.Repositorio.Usuario;
using MCE.Domain.Entities.Usuario;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MCE.Domain.Entities;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Seguranca;
using MCE.Domain.Dtos.Login;
using AutoMapper;

namespace MCE.Service.Servicos.Login
{
    public class ServicoDeLoginImpl : IServicoDeLogin
    {
        private IRepositorioUsuario _repositorioUsuario;

        private TokenConfiguracao _tokenConfiguracao;

        private ConfiguracaoDaAssinatura _configuracaoDaAssinatura;

        private IConfiguration _configuracao;

        private IMapper _mapper;

        public ServicoDeLoginImpl(IRepositorioUsuario repositorioUsuario,
                                TokenConfiguracao tokenConfiguracao,
                                ConfiguracaoDaAssinatura configuracaoDaAssinatura,
                                IConfiguration configuracao,
                                IMapper mapper)
        {
            _repositorioUsuario = repositorioUsuario;
            _tokenConfiguracao = tokenConfiguracao;
            _configuracaoDaAssinatura = configuracaoDaAssinatura;
            _configuracao = configuracao;
            _mapper = mapper;
        }

        public async Task<object> ConsulteLogin(DtoLogin dtoLogin)
        {
            if (dtoLogin != null && !string.IsNullOrWhiteSpace(dtoLogin.Email) && !string.IsNullOrWhiteSpace(dtoLogin.Senha))
            {
                var usuario = _mapper.Map<UsuarioEntity>(dtoLogin);
                var usuarioConsultado = await _repositorioUsuario.ConsulteLogin(usuario);

                if (usuarioConsultado == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(usuarioConsultado.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, usuarioConsultado.Email)
                        }
                    );

                    var dataDeCriacao = DateTime.Now;
                    var dataDeExpiracao = dataDeCriacao + TimeSpan.FromSeconds(_tokenConfiguracao.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var token = CreateToken(identity, dataDeCriacao, dataDeExpiracao, handler);
                    return SuccessObject(dataDeCriacao, dataDeExpiracao, token, usuarioConsultado);

                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguracao.Issuer,
                Audience = _tokenConfiguracao.Audience,
                SigningCredentials = _configuracaoDaAssinatura.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime datadeCriacao, DateTime dataDeExpiracao, string token, UsuarioEntity usuario)
        {
            return new
            {
                authenticated = true,
                create = datadeCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataDeExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = usuario.Email,
                name = usuario.Nome,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}
