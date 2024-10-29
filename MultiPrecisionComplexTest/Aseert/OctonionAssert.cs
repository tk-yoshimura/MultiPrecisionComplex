using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    public static class OctonionAssert<N> where N : struct, IConstant {

        public static void AreEqual(Octonion<N> expected, Octonion<N> actual, MultiPrecision<N> delta) {
            AreEqual(expected, actual, delta, string.Empty);
        }

        public static void AreEqual(Octonion<N> expected, Octonion<N> actual, MultiPrecision<N> delta, string message) {
            Assert.IsTrue(expected.R - delta < actual.R && expected.R + delta > actual.R &&
                          expected.I - delta < actual.I && expected.I + delta > actual.I &&
                          expected.J - delta < actual.J && expected.J + delta > actual.J &&
                          expected.K - delta < actual.K && expected.K + delta > actual.K &&
                          expected.W - delta < actual.W && expected.W + delta > actual.W &&
                          expected.X - delta < actual.X && expected.X + delta > actual.X &&
                          expected.Y - delta < actual.Y && expected.Y + delta > actual.Y &&
                          expected.Z - delta < actual.Z && expected.Z + delta > actual.Z,
                          message + $"\n{nameof(expected)} : {expected}\n{nameof(actual)}   : {actual}");
        }
    }
}
