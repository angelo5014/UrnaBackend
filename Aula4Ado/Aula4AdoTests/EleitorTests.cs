using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula4Ado;

namespace Aula4AdoTests
{
    [TestClass]
    public class EleitorTests
    {       
        Eleitor eleitorTeste = new Eleitor("Júlio", "99219998", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
        Eleitor eleitorTesteIgual = new Eleitor("Júlio", "99219998", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');    
    
        [TestMethod]
        public void EqualsTest()
        {
            Assert.AreEqual(eleitorTeste.Equals(eleitorTesteIgual), true);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string esperado = string.Format("{1}{2,-6} {3}{4,-40} {5}{6,-13} {7}{8,-13} {9}{10,-13}{0}{11}{12:dd/MM/yyyy} {13}{14,-6} {15}{16,-6} {17}{18,-3} {19}{20,-3}{0}",
                "\r\n", "ID: ", eleitorTeste.IdEleitor, "NOME: ", "Júlio", "TITULO:", "99219998", "RG :", "9996RS1", "CPF: ", "99000000326",
                "NASCIMENTO: ", new DateTime(1992, 12, 31), "ZONA: ", "51", "SEÇÃO: ", "N444", "SITUAÇÃO: ", 'A', "VOTOU: ", 'N');
            Assert.AreEqual(eleitorTeste.ToString(), esperado);
        }
    }
}
