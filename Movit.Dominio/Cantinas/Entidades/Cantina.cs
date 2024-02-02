using Movit.Dominio.Excecoes;
namespace Movit.Dominio.Cantinas.Entidades
{
    public class Cantina
    {
        public virtual int Id { get; protected set; }
        public virtual string NomeComida { get; protected set; }
        public virtual DateTime DataCantina { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual int Quantidade { get; protected set; }

        public Cantina(string nomeComida, DateTime dataCantina , decimal valor, int quantidade)
        {
            SetNomeComida(nomeComida);
            SetDataCantina(dataCantina);
            SetValor(valor);
            SetQuantidade(quantidade);
        }

        protected Cantina(){}
        public virtual void SetNomeComida(string nomeComida)
        {
            if(string.IsNullOrWhiteSpace(nomeComida))
            {
                throw new RegraDeNegocioExcecao("O nome da comida não pode vir vazio ou com espaço em branco");
            }
            NomeComida = nomeComida;
        }
        
        public virtual void SetDataCantina(DateTime dataCantina)
        {
            if (dataCantina == DateTime.MinValue)
            throw new AtributoInvalidoExcecao("Data cantina");

            DataCantina = dataCantina;
        }

        public virtual void SetValor(decimal valor)
        {
            if (valor <= 0)
            throw new RegraDeNegocioExcecao("O preço não pode ser menor ou igual a Zero.");

            Valor = valor;
        }

        public virtual void SetQuantidade(int quantidade)
        {
            if (quantidade < 0)
            throw new RegraDeNegocioExcecao("A quantidade não pode menor que Zero");

            Quantidade = quantidade;
        }
    }
}