using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class CargoTests
    {
        [TestMethod()]
        public void CargoTest()
        {
            Cargo cargo = new Cargo(23, "Cargo");
            Assert.AreEqual("Cargo", cargo.Nome);
            Assert.AreEqual(23, cargo.IdCargo);
            Assert.AreEqual('\0', cargo.Situacao);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string esperado = string.Format("{4,-10}{1}{0}{5,-10}{2}{0}{6,-10}{3}",
                Environment.NewLine, 96, "teste", 'A', "IdCargo:", "Nome:", "Situação:");
            Cargo atual = new Cargo(96, "teste")
            {
                Situacao = 'A'
            };
            Assert.AreEqual(esperado, atual.ToString());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Cargo cargo1 = new Cargo(96, "96");
            Cargo cargo2 = new Cargo(96, "96");
            Assert.AreEqual(cargo1, cargo2);
        }
    }
}