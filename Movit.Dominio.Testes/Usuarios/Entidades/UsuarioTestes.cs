using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Entidades;
using Xunit;

namespace Movit.Dominio.Testes.Usuarios.Entidades
{
    public class UsuarioTestes
    {
        private readonly Usuario sut;
        public UsuarioTestes()
        {
            sut = Builder<Usuario>.CreateNew().Build();
        }

        public class SetEmailMetodo : UsuarioTestes
        {
            [Theory]
            [InlineData("invalidemail")]
            [InlineData("missingat.com")]

            public void Dado_Email_NuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string email)
            {
                Action act = () => sut.SetEmail(email);
                act.Should().Throw<AtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_EmailValido_Espero_PropriedadesPreenchidas()
            {
                string email = "test@gmail.com";
                sut.SetEmail(email);
                sut.Email.Should().NotBeNullOrWhiteSpace(email);
                sut.Email.Should().Be(email);
            }
        }

        public class SetSenhaMetodo : UsuarioTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("      ")]
            public void QuandoSenhaNulaOuVazia_DeveLancarAtributoObrigatorioExcecao(string senha)
            {
                Assert.Throws<AtributoObrigatorioExcecao>(() => sut.SetSenha(senha));
            }

            [Theory]
            [InlineData("12345")] // Senha com menos de 6 caracteres
            [InlineData("123456789012345678901")] // Senha com mais de 20 caracteres
            public void QuandoSenhaForInvalidaTamanho_DeveLancarTamanhoDeAtributoInvalidoExcecao(string senha)
            {
                Assert.Throws<TamanhoDeAtributoInvalidoExcecao>(() => sut.SetSenha(senha));
            }

            [Theory]
            [InlineData("12345a")] // Senha sem letra maiúscula
            [InlineData("12345A")] // Senha sem letra minúscula
            [InlineData("12345Aa")] // Senha sem caractere especial
            public void QuandoSenhaNaoAtenderRequisitos_DeveLancarAtributoInvalidoExcecao(string senha)
            {
                Assert.Throws<AtributoInvalidoExcecao>(() => sut.SetSenha(senha));
            }

            [Theory]
            [InlineData("Senha@1")] // Senha válida
            [InlineData("senha@1A")] // Senha válida
            [InlineData("SENHA@1a")] // Senha válida
            public void QuandoSenhaAtenderTodosRequisitos_NaoDeveLancarExcecao(string senha)
            {
                sut.SetSenha(senha);
                Assert.Equal(senha, sut.Senha);
            }
        }
    }
}