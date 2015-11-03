using System;

namespace Aula4Ado
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public string Nome { get; set; }
        public string Slogan { get; set; }
        public string Sigla { get; set; }

        public Partido(string nome, string slogan, string sigla)
        {
            Nome = nome;
            Slogan = slogan;
            Sigla = sigla;
        }

        public override string ToString()
        {
            return string.Format("{5,-10}{1}{0}{6,-10}{2}{0}{7,-10}{3}{0}{8,-10}{4}",
                Environment.NewLine, IdPartido, Nome, Slogan, Sigla, "IdCargo:", "Nome:", "Situação:", "Sigla:");
        }

        public override bool Equals(object obj)
        {
            Partido cargo = (Partido)obj;
            return IdPartido == cargo.IdPartido && Nome == cargo.Nome
                && Slogan == cargo.Slogan && Sigla == cargo.Sigla;
        }
    }
}