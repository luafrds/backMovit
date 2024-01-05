using Movit.Dominio.Excecoes;
namespace Movit.Dominio.Cantinas.Entidades
{
    public class Cantina
    {
        public string NomeComida { get; protected set; }
        public DateTime DataCantina { get; protected set; }
        public decimal Valor { get; protected set; }
        public int Quantidade { get; protected set; }

        public Cantina(string nomeComida, DateTime dataCantina , decimal valor, int quantidade)
        {
            SetNomeComida(nomeComida);
            SetDataCantina(DateTime.Now);
            SetValor(valor);
            SetQuantidade(quantidade);
            
        }
        private void SetNomeComida(string nomeComida)
        {
            if(string.IsNullOrWhiteSpace(nomeComida))
            {
                throw new RegraDeNegocioExcecao("O nome da comida não pode vir vazio ou com espaço em branco");
            }
            NomeComida = nomeComida;
        }
        
        private void SetDataCantina(DateTime dataCantina)
        {
            if (dataCantina == DateTime.MinValue)
            throw new AtributoInvalidoExcecao("dataPedido");

            DataCantina = dataCantina;
        }

        private void SetValor(decimal valor)
        {
                if (valor <= 0)
                throw new RegraDeNegocioExcecao("O preço não pode ser menor ou igual a Zero.");

            Valor = valor;
        }

        private void SetQuantidade(int quantidade)
        {
            if (quantidade < 0)
            throw new RegraDeNegocioExcecao("A quantidade não pode menor que Zero");

        Quantidade = quantidade;
        }
    }
}