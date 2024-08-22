using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexExpTests {

        [TestMethod()]
        public void ExpTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Exp(z);
                NComplex nc = NComplex.Exp((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }
    }
}