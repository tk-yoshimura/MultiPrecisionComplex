using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionSinCosTests {

        [TestMethod()]
        public void SinCosTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sin(q), c = Quaternion<Pow2.N8>.Cos(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Sin(q.R), s.R, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Cos(q.R), c.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sin(q), c = Quaternion<Pow2.N8>.Cos(q);

                QuaternionAssert<Pow2.N8>.AreEqual(Quaternion<Pow2.N8>.One, s * s + c * c, 1e-23);
            }
        }

        [TestMethod()]
        public void TanTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> y = Quaternion<Pow2.N8>.Tan(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Tan(q.R), y.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sin(q), c = Quaternion<Pow2.N8>.Cos(q);
                Quaternion<Pow2.N8> t = Quaternion<Pow2.N8>.Tan(q);

                QuaternionAssert<Pow2.N8>.AreEqual(s / c, t, 1e-25);
            }
        }
    }
}