using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionExpTests {

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
    }
}