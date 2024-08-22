using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexSinhCoshTests {

        [TestMethod()]
        public void SinhTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Sinh(z);
                NComplex nc = NComplex.Sinh((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void CoshTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Cosh(z);
                NComplex nc = NComplex.Cosh((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void TanhTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Tanh(z);
                NComplex nc = NComplex.Tanh((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }
    }
}