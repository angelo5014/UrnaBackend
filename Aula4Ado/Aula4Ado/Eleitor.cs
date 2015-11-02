using System;

namespace Aula4Ado
{
    public class Eleitor
    {
        public int IdEleitor { get; internal set; }
        public string Nome { get; private set; }
        public string TituloEleitoral { get; private set; }
        internal string RG { get; private set; }
        internal string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string ZonaEleitoral { get; private set; }
        public string Secao { get; private set; }
        public char Situacao { get; internal set; }
        public char Votou { get; internal set; }

        public Eleitor(string nome, string tituloEleitoral, string rg, string cpf, DateTime dataNascimento, string zonaEleitoral, string secao, char situacao, char votou)
        {
            Nome = nome;
            TituloEleitoral = tituloEleitoral;
            RG = rg;
            CPF = cpf;
            DataNascimento = dataNascimento;
            ZonaEleitoral = zonaEleitoral;
            Secao = secao;
            Situacao = situacao;
            Votou = votou;
        }
    }
}