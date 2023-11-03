using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Tan(z);
                NComplex nc = NComplex.Tan((NComplex)z);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
            }
        }

        [TestMethod()]
        public void TanPITest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.TanPI(z);
                NComplex nc = NComplex.Tan((NComplex)(z * MultiPrecision<Pow2.N8>.PI));

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
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