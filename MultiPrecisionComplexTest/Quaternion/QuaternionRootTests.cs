using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionRootTests {

        [TestMethod()]
        public void SqrtTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> sqrt = Quaternion<Pow2.N8>.Sqrt(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Sqrt(q.R), sqrt.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1), (-2, 0, 0, 0), (-8, 0, 0, 0), (-8, 4, 0, 0) }) {
                Quaternion<Pow2.N8> sqrt = Quaternion<Pow2.N8>.Sqrt(q);

                QuaternionAssert<Pow2.N8>.AreEqual(q, sqrt * sqrt, 1e-25);
            }
        }

        [TestMethod()]
        public void CbrtTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> cbrt = Quaternion<Pow2.N8>.Cbrt(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Cbrt(q.R), cbrt.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1), (-2, 0, 0, 0), (-8, 0, 0, 0), (-8, 4, 0, 0) }) {
                Quaternion<Pow2.N8> cbrt = Quaternion<Pow2.N8>.Cbrt(q);

                QuaternionAssert<Pow2.N8>.AreEqual(q, cbrt * cbrt * cbrt, 1e-25);
            }
        }

        [TestMethod()]
        public void RootNTest() {
            static MultiPrecision<N> root_n<N>(MultiPrecision<N> x, int n) where N : struct, IConstant {
                return (x.Sign != Sign.Minus ? +1 : -1) * MultiPrecision<N>.Pow(MultiPrecision<N>.Abs(x), MultiPrecision<N>.Div(1, n));
            }

            foreach (int n in new[] { 1, 2, 3, 4, 5, 6, 7, 8 }) {
                foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                    Quaternion<Pow2.N8> y = Quaternion<Pow2.N8>.RootN(q, n);

                    QuaternionAssert<Pow2.N8>.AreEqual(root_n(q.R, n), y.R, 1e-25);
                }

                foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1), (-2, 0, 0, 0), (-8, 0, 0, 0), (-8, 4, 0, 0) }) {
                    Quaternion<Pow2.N8> y = Quaternion<Pow2.N8>.RootN(q, n);

                    QuaternionAssert<Pow2.N8>.AreEqual(q, Quaternion<Pow2.N8>.Pow(y, n), 1e-25);
                }
            }
        }
    }
}