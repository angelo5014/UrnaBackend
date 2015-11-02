using System;

namespace Aula4Ado
{
    public class Eleitor
    {
        public int IdEleitor { get; internal set; }
        public string Nome { get; set; }
        public string TituloEleitoral { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string ZonaEleitoral { get; private set; }
        public string Secao { get; private set; }
        public char Situacao { get; internal set; }
        public char Votou { get; set; }

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

        public override bool Equals(object obj)
        {
            Eleitor eleitor = (Eleitor)obj;
            return IdEleitor == eleitor.IdEleitor && Nome == eleitor.Nome && TituloEleitoral == eleitor.TituloEleitoral &&
                RG == eleitor.RG && CPF == eleitor.CPF && DataNascimento == eleitor.DataNascimento && ZonaEleitoral == eleitor.ZonaEleitoral &&
                Secao == eleitor.Secao && Situacao == eleitor.Situacao && Votou == eleitor.Votou;
        }

        public override string ToString()
        {
            return string.Format("{1}{2,-6} {3}{4,-40} {5}{6,-13} {7}{8,-13} {9}{10,-13}{0}{11}{12:dd/MM/yyyy} {13}{14,-6} {15}{16,-6} {17}{18,-3} {19}{20,-3}{0}",
                "\r\n", "ID: ", IdEleitor, "NOME: ", Nome, "TITULO:", TituloEleitoral, "RG :", RG, "CPF: ", CPF,
                "NASCIMENTO: ", DataNascimento, "ZONA: ", ZonaEleitoral, "SEÇÃO: ", Secao, "SITUAÇÃO: ", Situacao, "VOTOU: ", Votou);
        }
    }
}