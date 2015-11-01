using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula4Ado;

namespace Aula4AdoTests
{
    [TestClass]
    public class CandidatoTests
    {
        Candidato candidatoDeTeste = new Candidato(1, "Júlio César", "Júlio", new DateTime(1992,12,31), "000", 2, 3, 4, 0);
        Candidato candidatoDeTesteIgual = new Candidato(1, "Júlio César", "Júlio", new DateTime(1992, 12, 31), "000", 2, 3, 4, 0);

        [TestMethod]
        public void CandidatoToString()
        {
            string esperado = string.Format("{1} {2}, {3} {4}, {5} {6},{0}{7} {8:dd/MM/yyyy}, {9} {10}, {11} {12},{0}{13} {14}, {15} {16}, {17} {18}", "\r\n", 
                "Id do candidato:", "1", "Nome completo:", "Júlio César", "Nome popular:", "Júlio",
                "Data de nascimento:", "31/12/1992", "Registro TRE:", "000", "Id do partido:", "2",
                "Numero:", "3", "Id do cargo:", "4", "Exibe:", "0");

            Assert.AreEqual(esperado, candidatoDeTeste.ToString());
        }

        [TestMethod]
        public void CandidatoEquals()
        {
            Assert.AreEqual(true, candidatoDeTeste.Equals(candidatoDeTesteIgual));
        }
    }
}
