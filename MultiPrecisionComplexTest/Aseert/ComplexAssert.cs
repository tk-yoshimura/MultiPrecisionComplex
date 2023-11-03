using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    public static class ComplexAssert<N> where N : struct, IConstant {

        public static void AreEqual(Complex<N> expected, Complex<N> actual, MultiPrecision<N> delta) {
            AreEqual(expected, actual, delta, string.Empty);
        }

        public static void AreEqual(Complex<N> expected, Complex<N> actual, MultiPrecision<N> delta, string message) {
            Assert.IsTrue(expected.R - delta < actual.R && expected.R + delta > actual.R &&
                          expected.I - delta < actual.I && expected.I + delta > actual.I,
                          message + $"\n{nameof(expected)} : {expected}\n{nameof(actual)}   : {actual}");
        }
    }
}
