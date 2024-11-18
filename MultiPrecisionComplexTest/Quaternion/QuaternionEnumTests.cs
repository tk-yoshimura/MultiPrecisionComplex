using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionEnumTests {
        [TestMethod()]
        public void QuaternionSumTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            Assert.AreEqual((16, 1, 7, 13), qs.Sum());
        }

        [TestMethod()]
        public void QuaternionAverageTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            Assert.AreEqual((4, 0.25, 1.75, 3.25), qs.Average());
        }

        [TestMethod()]
        public void QuaternionRTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 1, 2, 6, 7 }, qs.R().ToArray());
        }

        [TestMethod()]
        public void QuaternionITest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 2, 5, -3, -3 }, qs.I().ToArray());
        }

        [TestMethod()]
        public void QuaternionJTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 3, -2, 1, 5 }, qs.J().ToArray());
        }

        [TestMethod()]
        public void QuaternionKTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { 4, 6, 2, 1 }, qs.K().ToArray());
        }

        [TestMethod()]
        public void QuaternionNormTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { qs[0].Norm, qs[1].Norm, qs[2].Norm, qs[3].Norm }, qs.Norm().ToArray());
        }

        [TestMethod()]
        public void QuaternionMagnitudeTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new MultiPrecision<Pow2.N4>[] { qs[0].Norm, qs[1].Norm, qs[2].Norm, qs[3].Norm }, qs.Magnitude().ToArray());
        }

        [TestMethod()]
        public void QuaternionConjugateTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new Quaternion<Pow2.N4>[] { qs[0].Conj, qs[1].Conj, qs[2].Conj, qs[3].Conj }, qs.Conjugate().ToArray());
        }

        [TestMethod()]
        public void QuaternionNormalTest() {
            Quaternion<Pow2.N4>[] qs = { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -3, 5, 1) };

            CollectionAssert.AreEqual(new Quaternion<Pow2.N4>[] { qs[0].Normal, qs[1].Normal, qs[2].Normal, qs[3].Normal }, qs.Normal().ToArray());
        }
    }
}