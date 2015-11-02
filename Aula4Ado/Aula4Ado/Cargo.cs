using System;

namespace Aula4Ado
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public char Situacao { get; set; }

        public Cargo(string nome, char situacao)
        {
            Nome = nome;
            Situacao = situacao;
        }

        public override string ToString()
        {
            return string.Format("{4,-10}{1}{0}{5,-10}{2}{0}{6,-10}{3}",
                Environment.NewLine, IdCargo, Nome, Situacao, "IdCargo:", "Nome:", "Situação:");
        }

        public override bool Equals(object obj)
        {
            Cargo cargo = (Cargo)obj;
            return IdCargo == cargo.IdCargo && Nome == cargo.Nome && Situacao == cargo.Situacao;
        }
    }
}