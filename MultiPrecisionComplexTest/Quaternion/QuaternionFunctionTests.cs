using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionFunctionTests {
        [TestMethod()]
        public void InverseTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Inverse(q);

                QuaternionAssert<Pow2.N8>.AreEqual(1, s * q, 1e-24);
            }
        }

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

        [TestMethod()]
        public void ExpTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> exp = Quaternion<Pow2.N8>.Exp(q);
                Quaternion<Pow2.N8> log = Quaternion<Pow2.N8>.Log(q);

                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Exp(q.R), exp.R, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Log(q.R), log.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> t = Quaternion<Pow2.N8>.Exp(Quaternion<Pow2.N8>.Log(q));

                QuaternionAssert<Pow2.N8>.AreEqual(q, t, 1e-25);
            }
        }

        [TestMethod()]
        public void PowTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { 1, 2, 4, 5 }) {
                Quaternion<Pow2.N8> pown1 = Quaternion<Pow2.N8>.Pow(q, -1);
                Quaternion<Pow2.N8> pow2 = Quaternion<Pow2.N8>.Pow(q, 2);
                Quaternion<Pow2.N8> pow3 = Quaternion<Pow2.N8>.Pow(q, 3);

                QuaternionAssert<Pow2.N8>.AreEqual(1 / q.R, pown1.R, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Pow(q.R, 2), pow2.R, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(MultiPrecision<Pow2.N8>.Pow(q.R, 3), pow3.R, 1e-25);
            }

            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1), (-2, 0, 0, 0), (-8, 0, 0, 0), (-8, 4, 0, 0) }) {
                Quaternion<Pow2.N8> pown1 = Quaternion<Pow2.N8>.Pow(q, -1);
                Quaternion<Pow2.N8> pow2 = Quaternion<Pow2.N8>.Pow(q, 2);
                Quaternion<Pow2.N8> pow3 = Quaternion<Pow2.N8>.Pow(q, 3);

                QuaternionAssert<Pow2.N8>.AreEqual(1 / q, pown1, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(q * q, pow2, 1e-25);
                QuaternionAssert<Pow2.N8>.AreEqual(q * q * q, pow3, 1e-25);
            }
        }

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