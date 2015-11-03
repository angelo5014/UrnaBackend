using System;

namespace Aula4Ado
{
    public class Voto
    {
        public int IdVoto { get; set; }
        public int Numero { get; set; }

        public Voto(int numero)
        {
            Numero = numero;
        }

        public override string ToString()
        {
            return string.Format("{3,-13}{1}{0}{4,-13}{2}",
                Environment.NewLine, IdVoto, Numero, "IdVoto:", "Numero:");
        }

        public override bool Equals(object obj)
        {
            Voto voto = (Voto)obj;
            return voto.Numero == Numero && voto.IdVoto == IdVoto;
        }
    }
}
