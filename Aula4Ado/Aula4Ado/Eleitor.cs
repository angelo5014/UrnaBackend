using System;

namespace Aula4Ado
{
    public class Eleitor
    {
        int IdEleitor { get; set; }
        string Nome { get; set; }
        string TituloEleitoral { get; set; }
        string RG { get; set; }
        string CPF { get; set; }
        DateTime DataNascimento { get; set; }
        string ZonaEleitoral { get; set; }
        string Secao { get; set; }
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