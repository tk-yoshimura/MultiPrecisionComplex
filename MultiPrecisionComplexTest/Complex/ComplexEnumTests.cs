using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class ComplexEnumTests {
        [TestMethod()]
        public void ComplexSumTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            Assert.AreEqual((16, 1), cs.Sum());
        }

        [TestMethod()]
        public void ComplexAverageTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            Assert.AreEqual((4, 0.25), cs.Average());
        }

        [TestMethod()]
        public void ComplexRTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 1, 2, 6, 7 }, cs.R().ToArray());
        }

        [TestMethod()]
        public void ComplexITest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 2, 5, -3, -3 }, cs.I().ToArray());
        }

        [TestMethod()]
        public void ComplexNormTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { cs[0].Norm, cs[1].Norm, cs[2].Norm, cs[3].Norm }, cs.Norm().ToArray());
        }

        [TestMethod()]
        public void ComplexMagnitudeTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { cs[0].Magnitude, cs[1].Magnitude, cs[2].Magnitude, cs[3].Magnitude }, cs.Magnitude().ToArray());
        }

        [TestMethod()]
        public void ComplexPhaseTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { cs[0].Phase, cs[1].Phase, cs[2].Phase, cs[3].Phase }, cs.Phase().ToArray());
        }

        [TestMethod()]
        public void ComplexConjugateTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new Complex<Pow2.N4>[] { cs[0].Conj, cs[1].Conj, cs[2].Conj, cs[3].Conj }, cs.Conjugate().ToArray());
        }

        [TestMethod()]
        public void ComplexNormalTest() {
            Complex<Pow2.N4>[] cs = { (1, 2), (2, 5), (6, -3), (7, -3) };

            CollectionAssert.AreEqual(new Complex<Pow2.N4>[] { Complex<Pow2.N4>.Normal(cs[0]), Complex<Pow2.N4>.Normal(cs[1]), Complex<Pow2.N4>.Normal(cs[2]), Complex<Pow2.N4>.Normal(cs[3]) }, cs.Normal().ToArray());
        }
    }
}