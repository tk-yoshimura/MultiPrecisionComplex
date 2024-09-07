using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class ComplexConjugateTests {
        [TestMethod()]
        public void ComplexConjugateTest() {
            Complex<Pow2.N8> c = (2, 3);

            Assert.AreEqual((2, -3), Complex<Pow2.N8>.Conjugate(c));
            Assert.AreEqual((2, -3), c.Conj);
        }
    }
}