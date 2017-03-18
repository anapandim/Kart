using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kart;

namespace KartTest
{
    [TestClass]
    public class TestRank
    {
        [TestMethod]
        public void TestOperator()
        {
            var r = new Log { Hora = Convert.ToDateTime("23:49:08.277"), NumeroVolta = 1, Piloto = "038 - F.MASSA"};

            var rank = (Rank)r;

            Assert.AreEqual("23:49:08.277", rank.Hora.ToString("HH:mm:ss.fff"), "erro convertendo hora");
            Assert.AreEqual("038", rank.CodigoPiloto, "erro convertendo código do piloto");
            Assert.AreEqual("F.MASSA", rank.NomePiloto, "erro convertendo nome do piloto");
            Assert.AreEqual(1, rank.QuantidadeVoltas, "erro convertendo quantidade de voltas");
        }
    }
}
