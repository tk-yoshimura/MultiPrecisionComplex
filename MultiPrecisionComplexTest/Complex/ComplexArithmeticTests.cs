using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NComplex = System.Numerics.Complex;

    [TestClass()]
    public class ComplexArithmeticTests {
        [TestMethod()]
        public void AddTest() {
            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a + b;
                    NComplex nc = (NComplex)a + (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 3, 4, -1, 2, 7 }) {
                    Complex<Pow2.N8> c = a + b;
                    NComplex nc = (NComplex)a + new NComplex((double)b, 0);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 3, 4, -1, 2, 7 }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a + b;
                    NComplex nc = new NComplex((double)a, 0) + (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void SubTest() {
            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a - b;
                    NComplex nc = (NComplex)a - (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 3, 4, -1, 2, 7 }) {
                    Complex<Pow2.N8> c = a - b;
                    NComplex nc = (NComplex)a - new NComplex((double)b, 0);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 3, 4, -1, 2, 7 }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a - b;
                    NComplex nc = new NComplex((double)a, 0) - (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void MulTest() {
            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a * b;
                    NComplex nc = (NComplex)a * (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 3, 4, -1, 2, 7 }) {
                    Complex<Pow2.N8> c = a * b;
                    NComplex nc = (NComplex)a * new NComplex((double)b, 0);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 3, 4, -1, 2, 7 }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a * b;
                    NComplex nc = new NComplex((double)a, 0) * (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void DivTest() {
            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a / b;
                    NComplex nc = (NComplex)a / (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                    ComplexAssert<Pow2.N8>.AreEqual(a, c * b, 1e-30);
                }
            }

            foreach (Complex<Pow2.N8> a in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 3, 4, -1, 2, 7 }) {
                    Complex<Pow2.N8> c = a / b;
                    NComplex nc = (NComplex)a / new NComplex((double)b, 0);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 3, 4, -1, 2, 7 }) {
                foreach (Complex<Pow2.N8> b in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                    Complex<Pow2.N8> c = a / b;
                    NComplex nc = new NComplex((double)a, 0) / (NComplex)b;

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }


        [TestMethod()]
        public void InverseTest() {
            foreach (Complex<Pow2.N8> z in new[] { (1, 2), (2, 5), (6, -3), (7, -4), (3, -9), (7, 1), (-3, -4), (-1, -9), (-2, 1) }) {
                Complex<Pow2.N8> c = Complex<Pow2.N8>.Inverse(z);

                ComplexAssert<Pow2.N8>.AreEqual(1, c * z, 1e-7);
            }
        }

        [TestMethod()]
        public void FromPhaseTest() {
            foreach (double theta in new[] { 0.25, 0.5, 0.75 }) {

                Complex<Pow2.N8> c = Complex<Pow2.N8>.FromPhase(theta);
                NComplex nc = NComplex.FromPolarCoordinates(1, theta);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
            }

            foreach (double theta in new[] { 0.25, 0.5, 0.75 }) {

                Complex<Pow2.N8> c = Complex<Pow2.N8>.FromPhasePi(theta);
                NComplex nc = NComplex.FromPolarCoordinates(1, theta * double.Pi);

                ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
            }
        }

        [TestMethod()]
        public void FromPolarTest() {
            foreach (double norm in new[] { 0.5, 1, 2, 4 }) {
                foreach (double theta in new[] { 0.25, 0.5, 0.75 }) {

                    Complex<Pow2.N8> c = Complex<Pow2.N8>.FromPolar(norm, theta);
                    NComplex nc = NComplex.FromPolarCoordinates(norm, theta);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                }
            }

            foreach (double norm in new[] { 0.5, 1, 2, 4 }) {
                foreach (double theta in new[] { 0.25, 0.5, 0.75 }) {

                    Complex<Pow2.N8> c = Complex<Pow2.N8>.FromPolarPi(norm, theta);
                    NComplex nc = NComplex.FromPolarCoordinates(norm, theta * double.Pi);

                    ComplexAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                }
            }
        }
    }
}
