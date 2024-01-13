using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Movit.Dominio.Autenticacoes.Servicos.Interfaces;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Enumeradores;

namespace Movit.Dominio.Autenticacoes.Servicos
{
    public class AutenticacoesServico : IAutenticacoesServico
    {
        public virtual string GerarToken(Usuario usuario)
        {
            SymmetricSecurityKey chave = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
               );
            SigningCredentials credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            Claim[] claimsCliente = new Claim[]
            {
                new Claim("id", usuario.Id.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimsCliente,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Usuario ValidarCadastro(string email, string senha, int tipoUsuario)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new RegraDeNegocioExcecao("Email inválido");
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new RegraDeNegocioExcecao("Senha inválida");
            }

            TipoUsuarioEnum tipoUsuarioEnum;

            switch (tipoUsuario)
            {
                case 1:
                    tipoUsuarioEnum = TipoUsuarioEnum.Integrante;
                    break;

                case 2:
                    tipoUsuarioEnum = TipoUsuarioEnum.Lider;
                    break;

                case 3:
                    tipoUsuarioEnum = TipoUsuarioEnum.Administrador;
                    break;

                default:
                    throw new RegraDeNegocioExcecao("Tipo de usuário inválido");
            }

            Usuario usuario = new Usuario(email, senha, tipoUsuarioEnum);
            return usuario;
        }


        public Usuario ValidarLogin(Usuario usuario, string senha)
        {
            if (usuario is null)
            {
                throw new RegraDeNegocioExcecao("Email incorreto");
            }
            if (!BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                throw new RegraDeNegocioExcecao("Senha incorreta");
            }
            return usuario;
        }
    }
}