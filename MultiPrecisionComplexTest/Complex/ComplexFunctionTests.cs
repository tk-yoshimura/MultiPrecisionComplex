﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexFunctionTests {
        [TestMethod()]
        public void InverseTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Inverse(z);

                ComplexAssert<Pow2.N8>.AreEqual(1, c * z, 1e-7);
            }
        }

        [TestMethod()]
        public void SinTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Sin(z);
                NComplex nc = NComplex.Sin((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void SinPITest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.SinPI(z);
                NComplex nc = NComplex.Sin((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

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
        public void CosPITest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.CosPI(z);
                NComplex nc = NComplex.Cos((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

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

                        Complex<Pow2.N8> c = Complex<Pow2.N8>.Tan((z + x) * MultiPrecision<Pow2.N8>.PI);
                        NComplex nc = -1 / NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

                        Console.WriteLine(z);
                        Console.WriteLine(c);
                        Console.WriteLine(nc);

                        Assert.AreEqual(nc.Real, (double)c.R, double.Abs(nc.Real) * 1e-7 + 1e-15);
                        Assert.AreEqual(nc.Imaginary, (double)c.I, double.Abs(nc.Imaginary) * 1e-7 + 1e-15);
                    }
                }
            }

            for (MultiPrecision<Pow2.N8> eps = 1d / 65536; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N8> z_pi = z * MultiPrecision<Pow2.N8>.PI, z_pi2 = z_pi * z_pi;

                    Complex<Pow2.N8> expected = -638512875 / (z_pi * (638512875 + z_pi2 * (212837625 + z_pi2 * (85135050 +
                        z_pi2 * (34459425 + z_pi2 * (13963950 + z_pi2 * (5659290 + z_pi2 * (2293620 + z_pi2 * 929569))))))));

                    Complex<Pow2.N8> actual = Complex<Pow2.N8>.Tan(z_pi + 0.5 * MultiPrecision<Pow2.N8>.PI);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N8>.Abs(expected.R) * 1e-35 + 1e-35);
                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N8>.Abs(expected.I) * 1e-35 + 1e-35);
                }
            }
        }

        [TestMethod()]
        public void TanPITest() {
            foreach (Complex<Pow2.N8> z in new[] { (0, 0), (0, 0.25),
                (1, 2), (2, 5), (6, -3), (7, -4), (-6, -3), (-7, -4),
                (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1),
                (-2, 32), (-2, -32), (-2, 256), (-2, -256) }) {

                Complex<Pow2.N8> c = Complex<Pow2.N8>.TanPI(z);
                NComplex nc = NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void TanPINearPoleTest() {
            for (MultiPrecision<Pow2.N8> eps = "0.1"; eps >= "1e-8"; eps /= 10) {
                foreach (MultiPrecision<Pow2.N8> x in new[] { -4.5, -3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5, 4.5 }) {
                    foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {

                        Complex<Pow2.N8> c = Complex<Pow2.N8>.TanPI(z + x);
                        NComplex nc = -1 / NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

                        Console.WriteLine(z);
                        Console.WriteLine(c);
                        Console.WriteLine(nc);

                        Assert.AreEqual(nc.Real, (double)c.R, double.Abs(nc.Real) * 1e-7 + 1e-280);
                        Assert.AreEqual(nc.Imaginary, (double)c.I, double.Abs(nc.Imaginary) * 1e-7 + 1e-280);
                    }
                }
            }

            for (MultiPrecision<Pow2.N8> eps = 1d / 65536; eps.Exponent >= -128; eps /= 2) {
                foreach (Complex<Pow2.N8> z in new[] { (eps, eps), (eps, 0), (eps, -eps), (0, eps), (0, -eps), (-eps, eps), (-eps, 0), (-eps, -eps) }) {
                    Complex<Pow2.N8> z_pi = z * MultiPrecision<Pow2.N8>.PI, z_pi2 = z_pi * z_pi;

                    Complex<Pow2.N8> expected = -638512875 / (z_pi * (638512875 + z_pi2 * (212837625 + z_pi2 * (85135050 +
                        z_pi2 * (34459425 + z_pi2 * (13963950 + z_pi2 * (5659290 + z_pi2 * (2293620 + z_pi2 * 929569))))))));

                    Complex<Pow2.N8> actual = Complex<Pow2.N8>.TanPI(z + 0.5);

                    Console.WriteLine(z);
                    Console.WriteLine(expected);
                    Console.WriteLine(actual);

                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.R - actual.R) < MultiPrecision<Pow2.N8>.Abs(expected.R) * 1e-65 + 1e-50);
                    Assert.IsTrue(MultiPrecision<Pow2.N8>.Abs(expected.I - actual.I) < MultiPrecision<Pow2.N8>.Abs(expected.I) * 1e-65 + 1e-50);
                }
            }
        }

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

        [TestMethod()]
        public void AsinTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Asin(z);
                NComplex nc = NComplex.Asin((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void AcosTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Acos(z);
                NComplex nc = NComplex.Acos((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void AtanTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Atan(z);
                NComplex nc = NComplex.Atan((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void LogTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Log(z);
                NComplex nc = NComplex.Log((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void Log2Test() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Log2(z);
                NComplex nc = NComplex.Log((NComplex)z, 2);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void Log10Test() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Log10(z);
                NComplex nc = NComplex.Log10((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void LogNTest() {
            foreach (int n in new[] { 3, 5, 6 }) {
                foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.Log(z, n);
                    NComplex nc = NComplex.Log((NComplex)z, n);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void ExpTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Exp(z);
                NComplex nc = NComplex.Exp((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

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

        [TestMethod()]
        public void SqrtTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Sqrt(z);
                NComplex nc = NComplex.Sqrt((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void CbrtTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Cbrt(z);
                NComplex nc = NComplex.Pow((NComplex)z, 1d / 3d);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void RootNTest() {
            foreach (int n in new[] { 1, 2, 3, 4, 5, 6, 7, 8 }) {
                foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = Complex<Pow2.N8>.RootN(z, n);
                    NComplex nc = NComplex.Pow((NComplex)z, 1d / n);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }
    }
}