using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionSinhCoshTests {

        [TestMethod()]
        public void SinhCoshTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sinh(q), c = Quaternion<Pow2.N8>.Cosh(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Sinh(q.R), s.R, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Cosh(q.R), c.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sinh(q), c = Quaternion<Pow2.N8>.Cosh(q);

                QuaternionAssert<Pow2.N8>.AreEqual(Quaternion<Pow2.N8>.One, c * c - s * s, 1e-23);
            }
        }

        [TestMethod()]
        public void TanhTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> y = Quaternion<Pow2.N8>.Tanh(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Tanh(q.R), y.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Sinh(q), c = Quaternion<Pow2.N8>.Cosh(q);
                Quaternion<Pow2.N8> t = Quaternion<Pow2.N8>.Tanh(q);

                QuaternionAssert<Pow2.N8>.AreEqual(s / c, t, 1e-25);
            }
        }
    }
}