using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionConjugateTests {
        [TestMethod()]
        public void QuaternionConjugateTest() {
            Quaternion<Pow2.N8> c = (2, 3, 4, 5);

            Assert.AreEqual((2, -3, -4, -5), Quaternion<Pow2.N8>.Conjugate(c));
        }
    }
}