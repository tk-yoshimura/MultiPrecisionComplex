using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexPowTests {

        [TestMethod()]
        public void PowTest() {
            foreach (Complex<Pow2.N8> p in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.Pow(z, p);
                    NComplex nc = NComplex.Pow((NComplex)z, (NComplex)p);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, nc.Magnitude * 1e-7);
                }
            }

            foreach (Complex<Pow2.N8> p in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (MultiPrecision<Pow2.N8> x in new[] { 1, 1.5, 2, 2.5, 3, 6, 7, 10 }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.Pow(x, p);
                    NComplex nc = NComplex.Pow((double)x, (NComplex)p);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, nc.Magnitude * 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> p in new[] { 1, 1.5, 2, 2.5, 3, 6, 7, 10 }) {
                foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.Pow(z, p);
                    NComplex nc = NComplex.Pow((NComplex)z, (double)p);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, nc.Magnitude * 1e-7);
                }
            }
        }

        [TestMethod()]
        public void Pow2Test() {
            foreach (Complex<Pow2.N8> p in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Pow2(p);
                NComplex nc = NComplex.Pow(2, (NComplex)p);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, nc.Magnitude * 1e-7);
            }
        }

        [TestMethod()]
        public void PowNTest() {
            foreach (int n in new[] { 3, 5, 6 }) {
                foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.Pow(z, n);
                    NComplex nc = NComplex.Pow((NComplex)z, n);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, nc.Magnitude * 1e-7);
                }
            }
        }
    }
}