using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kart;

namespace KartTest
{
    [TestClass]
    public class TestLog
    {
        [TestMethod]
        public void TestOperator()
        {
            var s = "23:49:08.277	038 - F.MASSA	1	1:02.852	44,275";

            var log = (Log)s;

            Assert.AreEqual("23:49:08.277", log.Hora.ToString("HH:mm:ss.fff"), "erro convertendo hora");
            Assert.AreEqual("038 - F.MASSA", log.Piloto, "erro convertendo dados do piloto");
            Assert.AreEqual(1, log.NumeroVolta, "erro convertendo número da volta");
        }
    }
}
