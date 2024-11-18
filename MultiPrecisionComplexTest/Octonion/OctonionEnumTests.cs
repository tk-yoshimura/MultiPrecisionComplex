using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class OctonionEnumTests {
        [TestMethod()]
        public void OctonionSumTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            Assert.AreEqual((16, 1, 7, 13, 8, 6, 17, 27), qs.Sum());
        }

        [TestMethod()]
        public void OctonionAverageTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            Assert.AreEqual((4, 0.25, 1.75, 3.25, 2, 1.5, 4.25, 6.75), qs.Average());
        }

        [TestMethod()]
        public void OctonionRTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 1, 2, 6, 7 }, qs.R().ToArray());
        }

        [TestMethod()]
        public void OctonionITest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 2, 5, -3, -3 }, qs.I().ToArray());
        }

        [TestMethod()]
        public void OctonionJTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 3, -2, 1, 5 }, qs.J().ToArray());
        }

        [TestMethod()]
        public void OctonionKTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 4, 6, 2, 1 }, qs.K().ToArray());
        }

        [TestMethod()]
        public void OctonionWTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 2, 3, 7, -4 }, qs.W().ToArray());
        }

        [TestMethod()]
        public void OctonionXTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 5, 2, 1, -2 }, qs.X().ToArray());
        }

        [TestMethod()]
        public void OctonionYTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 7, 4, 5, 1 }, qs.Y().ToArray());
        }

        [TestMethod()]
        public void OctonionZTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 8, 6, 6, 7 }, qs.Z().ToArray());
        }

        [TestMethod()]
        public void OctonionNormTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { qs[0].Norm, qs[1].Norm, qs[2].Norm, qs[3].Norm }, qs.Norm().ToArray());
        }

        [TestMethod()]
        public void OctonionMagnitudeTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { qs[0].Norm, qs[1].Norm, qs[2].Norm, qs[3].Norm }, qs.Magnitude().ToArray());
        }

        [TestMethod()]
        public void OctonionConjugateTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new Octonion<Pow2.N4>[] { qs[0].Conj, qs[1].Conj, qs[2].Conj, qs[3].Conj }, qs.Conjugate().ToArray());
        }

        [TestMethod()]
        public void OctonionNormalTest() {
            Octonion<Pow2.N4>[] qs = { (1, 2, 3, 4, 2, 5, 7, 8), (2, 5, -2, 6, 3, 2, 4, 6), (6, -3, 1, 2, 7, 1, 5, 6), (7, -3, 5, 1, -4, -2, 1, 7) };

            CollectionAssert.AreEqual(new Octonion<Pow2.N4>[] { qs[0].Normal, qs[1].Normal, qs[2].Normal, qs[3].Normal }, qs.Normal().ToArray());
        }
    }
}