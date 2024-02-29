using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Cidades.Entidades
{
    public class Cidade
    {
        public virtual int Id { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual Estado Estado { get; protected set; }

    public Cidade(string descricao, Estado estado)
    {
        SetDescricao(descricao);
        SetEstado(estado);
    }

    protected Cidade() {}

    public virtual void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new AtributoObrigatorioExcecao("Descrição");

        if (descricao.Length < 3 || descricao.Length > 100)
            throw new TamanhoDeAtributoInvalidoExcecao("Descrição", 3, 100);

        Descricao = descricao;
    }

    public virtual void SetEstado(Estado estado)
    {
        Estado = estado ?? throw new AtributoObrigatorioExcecao("Estado");
    }

        public void SetEstado(object estadoValido)
        {
            throw new NotImplementedException();
        }
    }
}