using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    public class Eleicao
    {
        public Eleicao(int idDoCandidato)
        {
            BuscarPorId(idDoCandidato);
        }

        public static bool IniciarEleicoes(int parametro)
        {
            bool resultado;
            if (parametro == 1)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            return resultado;

            
        }

        public static bool FinalizarEleicoes(int parametro)
        {
            bool resultado;

            if (parametro == 1)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
    }
}
