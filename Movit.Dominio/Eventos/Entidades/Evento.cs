using System.Text.RegularExpressions;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Excecoes;

namespace Movit.Dominio.Eventos.Entidades
{
    public class Evento
    {
        public virtual int Id { get; protected set; }
        public virtual string Titulo { get; protected set; }
        public virtual DateTime DataEvento { get; protected set; }
        public virtual string Cep { get; protected set; }
        public virtual string Logradouro { get; protected set; }
        public virtual Cidade Cidade { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual string Complemento { get; protected set; }

        protected Evento() { }

        public Evento(string titulo, DateTime dataEvento, string cep, string logradouro, Cidade cidade, string numero, string complemento)
        {
            SetTitulo (titulo);
            SetDataEvento (dataEvento);
            SetCep (cep);
            SetLogradouro (logradouro);
            SetCidade (cidade);
            SetNumero (numero);
            SetComplemento (complemento);
        }

        public virtual void SetTitulo(string titulo)
        {
            if(string.IsNullOrWhiteSpace(titulo))
            {
                throw new RegraDeNegocioExcecao("O titulo do evento não pode vir vazio ou com espaço em branco");
            }
            Titulo = titulo;
        }

        public virtual void SetDataEvento(DateTime dataEvento)
        {
            if (dataEvento == DateTime.MinValue)
            throw new AtributoInvalidoExcecao("Data evento");

            DataEvento = dataEvento;
        }

        public virtual void SetCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new AtributoObrigatorioExcecao("CEP");
            }

            bool validador = Regex.IsMatch(cep, @"^\d{5}-?\d{3}$");
            
            if (cep!.Replace("-", "").Length != 8)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Cep");
            }
                
            if (!validador)
            {
                throw new AtributoInvalidoExcecao("Cep");
            }
                
            Cep = cep.Replace("-", "");
        }

        public virtual void SetLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
                throw new AtributoObrigatorioExcecao("Logradouro");

            if (logradouro.Length > 50)
                throw new TamanhoDeAtributoInvalidoExcecao("Logradouro", null, tamanhoMaximo: 50);

            Logradouro = logradouro;
        }

        public virtual void SetCidade(Cidade cidade)
        {
            Cidade = cidade ?? throw new AtributoObrigatorioExcecao("Cidade");
        }

        public virtual void SetNumero(string numero)
        {
            if (numero.Length > 6)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("O número deve conter no máximo 6 dígitos.");
            }
            Numero = numero;
        }

        public virtual void SetComplemento(string complemento)
        {
            if (complemento.Length > 50)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("O complemento deve conter no máximo 50 dígitos.");
            }
            Complemento = complemento;
        }
    }
}