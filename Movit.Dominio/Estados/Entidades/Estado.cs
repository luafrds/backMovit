using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Estados.Entidades
{
    public class Estado
    {
    public virtual int Id { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public virtual string Sigla { get; protected set; }

    protected Estado() { }

    public Estado(string descricao, string sigla)
    {
        SetDescricao(descricao);
        SetSigla(sigla);
    }

        public virtual void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new AtributoObrigatorioExcecao("Descrição");

        if (descricao.Length > 150)
            throw new TamanhoDeAtributoInvalidoExcecao("Descrição", null, tamanhoMaximo: 150);

        Descricao = descricao;
    }

    public virtual void SetSigla(string sigla)
    {
        if (string.IsNullOrWhiteSpace(sigla))
            throw new AtributoObrigatorioExcecao("UF");

        if (sigla.Length != 2)
            throw new TamanhoDeAtributoInvalidoExcecao("UF", 2, 2);

        Sigla = sigla;
    }
    }
}