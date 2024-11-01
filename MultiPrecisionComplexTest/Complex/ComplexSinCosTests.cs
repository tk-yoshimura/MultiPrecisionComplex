using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexSinCosTests {

        [TestMethod()]
        public void SinTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Sin(z);
                NComplex nc = NComplex.Sin((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void SinPiTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.SinPi(z);
                NComplex nc = NComplex.Sin((NComplex)(z * MultiPrecision<Pow2.N8>.Pi));

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-2);
            }
        }

        [TestMethod()]
        public void CosTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Cos(z);
                NComplex nc = NComplex.Cos((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void CosPiTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.CosPi(z);
                NComplex nc = NComplex.Cos((NComplex)(z * MultiPrecision<Pow2.N8>.Pi));

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-2);
            }
        }

        [TestMethod()]
        public void TanTest() {
            foreach (Complex<Pow2.N8> z in new[] { (0, 0), (0, 0.25),
                (1, 2), (2, 5), (6, -3), (7, -4), (-6, -3), (-7, -4),
                (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1),
                (-2, 32), (-2, -32), (-2, 256), (-2, -256) }) {

                Complex<Pow2.N8> c = Complex<Pow2.N8>.Tan(z);
                NComplex nc = NComplex.Tan((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void TanNearPoleTest() {
            for (MultiPrecision<Pow2.N8> eps = "0.1"; eps >= "1e-8"; eps /= 10) {
                foreach (MultiPrecision<Pow2.N8> x in new[] { -4.5, -3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5, 4.5 }) {
                    foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {

                        Complex<Pow2.N8> c = Complex<Pow2.N8>.Tan((z + x) * MultiPrecision<Pow2.N8>.Pi);
                        NComplex nc = -1 / NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.Pi));

                        Console.WriteLine(z);
                        Console.WriteLine(c);
                        Console.WriteLine(nc);

                        Assert.AreEqual(nc.Real, (double)c.R, double.Abs(nc.Real) * 1e-7 + 1e-15);
                        Assert.AreEqual(nc.Imaginary, (double)c.I, double.Abs(nc.Imaginary) * 1e-7 + 1e-15);
                    }
                }
            }

            for (MultiPrecision<Pow2.N8> eps = 1d / 4; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N8> expected = (-Complex<Pow2.N16>.CosPi(z.Convert<Pow2.N16>()) / Complex<Pow2.N16>.SinPi(z.Convert<Pow2.N16>())).Convert<Pow2.N8>();

                    Complex<Pow2.N8> actual = Complex<Pow2.N8>.Tan((z + 0.5) * MultiPrecision<Pow2.N8>.Pi);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N8>.Abs(expected.R) * 1e-35 + 1e-20);
                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N8>.Abs(expected.I) * 1e-35 + 1e-20);
                }
            }

            for (MultiPrecision<Pow2.N16> eps = 1d / 4; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N16> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N16> expected = (-Complex<Pow2.N32>.CosPi(z.Convert<Pow2.N32>()) / Complex<Pow2.N32>.SinPi(z.Convert<Pow2.N32>())).Convert<Pow2.N16>();

                    Complex<Pow2.N16> actual = Complex<Pow2.N16>.Tan((z + 0.5) * MultiPrecision<Pow2.N16>.Pi);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N16>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N16>.Abs(expected.R) * 1e-70 + 1e-40);
                    Assert.IsTrue(MultiPrecision<Pow2.N16>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N16>.Abs(expected.I) * 1e-70 + 1e-40);
                }
            }
        }

        [TestMethod()]
        public void TanPiTest() {
            foreach (Complex<Pow2.N8> z in new[] { (0, 0), (0, 0.25),
                (1, 2), (2, 5), (6, -3), (7, -4), (-6, -3), (-7, -4),
                (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1),
                (-2, 32), (-2, -32), (-2, 256), (-2, -256) }) {

                Complex<Pow2.N8> c = Complex<Pow2.N8>.TanPi(z);
                NComplex nc = NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.Pi));

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void TanPiNearPoleTest() {
            for (MultiPrecision<Pow2.N8> eps = "0.1"; eps >= "1e-8"; eps /= 10) {
                foreach (MultiPrecision<Pow2.N8> x in new[] { -4.5, -3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5, 4.5 }) {
                    foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {

                        Complex<Pow2.N8> c = Complex<Pow2.N8>.TanPi(z + x);
                        NComplex nc = -1 / NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.Pi));

                        Console.WriteLine(z);
                        Console.WriteLine(c);
                        Console.WriteLine(nc);

                        Assert.AreEqual(nc.Real, (double)c.R, double.Abs(nc.Real) * 1e-7 + 1e-280);
                        Assert.AreEqual(nc.Imaginary, (double)c.I, double.Abs(nc.Imaginary) * 1e-7 + 1e-280);
                    }
                }
            }

            for (MultiPrecision<Pow2.N8> eps = 1d / 4; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N8> expected = (-Complex<Pow2.N16>.CosPi(z.Convert<Pow2.N16>()) / Complex<Pow2.N16>.SinPi(z.Convert<Pow2.N16>())).Convert<Pow2.N8>();

                    Complex<Pow2.N8> actual = Complex<Pow2.N8>.TanPi(z + 0.5);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N8>.Abs(expected.R) * 1e-70 + 1e-50);
                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N8>.Abs(expected.I) * 1e-70 + 1e-50);
                }
            }

            for (MultiPrecision<Pow2.N16> eps = 1d / 4; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N16> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N16> expected = (-Complex<Pow2.N32>.CosPi(z.Convert<Pow2.N32>()) / Complex<Pow2.N32>.SinPi(z.Convert<Pow2.N32>())).Convert<Pow2.N16>();

                    Complex<Pow2.N16> actual = Complex<Pow2.N16>.TanPi(z + 0.5);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N16>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N16>.Abs(expected.R) * 1e-140 + 1e-100);
                    Assert.IsTrue(MultiPrecision<Pow2.N16>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N16>.Abs(expected.I) * 1e-140 + 1e-100);
                }
            }
        }
    }
}