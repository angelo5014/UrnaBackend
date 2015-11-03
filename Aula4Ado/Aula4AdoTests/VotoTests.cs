using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class VotoTests
    {
        [TestMethod()]
        public void VotoTest()
        {
            Voto atual = new Voto(3412);
            Assert.AreEqual(3412, atual.Numero);
            Assert.AreEqual(0, atual.IdVoto);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Voto atual = new Voto(3412);
            string esperado = string.Format("{3,-13}{1}{0}{4,-13}{2}",
                Environment.NewLine, atual.IdVoto, atual.Numero, "IdVoto:", "Numero:");
            Assert.AreEqual(esperado, atual.ToString());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Voto esperado = new Voto(3412);
            Voto atual = new Voto(3412);

            Assert.AreEqual(esperado, atual);
        }
    }
}