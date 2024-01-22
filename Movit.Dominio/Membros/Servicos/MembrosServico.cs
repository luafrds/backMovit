using Movit.Dominio.Excecoes;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios;
using Movit.Dominio.Membros.Servicos.Comandos;
using Movit.Dominio.Membros.Servicos.Interfaces;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Servicos.Interfaces;

namespace Movit.Dominio.Membros.Servicos
{
    public class MembrosServico : IMembrosServico
    {
        private readonly IMembrosRepositorio membrosRepositorio;
        private readonly IUsuariosServico usuariosServico;
        public MembrosServico(IMembrosRepositorio membrosRepositorio, IUsuariosServico usuariosServico)
        {
            this.membrosRepositorio = membrosRepositorio;
            this.usuariosServico = usuariosServico;
        }
        public async Task<Membro> EditarAsync(MembroComando comando)
        {
            Usuario usuario = await usuariosServico.ValidarAsync(comando.IdUsuario); 
            Membro membro = await ValidarAsync(comando.Id);
            membro.SetNomeCompleto(comando.NomeCompleto);
            membro.SetEmail(comando.Email);
            membro.SetDataNascimento(comando.DataNascimento);
            membro.SetUsuario(usuario);
            await membrosRepositorio.EditarAsync(membro);
            return membro;
        }
        
        public async Task<Membro> InserirAsync(MembroComando comando)
        {
            Usuario usuario = await usuariosServico.ValidarAsync(comando.IdUsuario); 
            Membro membro = new(comando.NomeCompleto, comando.Email, comando.DataNascimento, usuario);
            await membrosRepositorio.InserirAsync(membro);
            return membro;
        }

        public async Task<Membro> ValidarAsync(int id)
        {
            Membro membro = await membrosRepositorio.RecuperarAsync(id);
            if(membro == null)
            throw new RegraDeNegocioExcecao("Membro não encontrado");
            return membro;
        }
    }
}