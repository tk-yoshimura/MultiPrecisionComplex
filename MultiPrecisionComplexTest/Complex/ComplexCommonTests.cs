using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class ComplexCommonTests {
        [TestMethod()]
        public void ComplexTest() {
            Complex<Pow2.N8> c1 = new(2, 3);
            Complex<Pow2.N8> c2 = (4, 5);
            Complex<Pow2.N8> c3 = 6;

            Assert.AreEqual(2, c1.R);
            Assert.AreEqual(3, c1.I);
            Assert.AreEqual((double)0.98279, (double)c1.Phase, 1e-4);

            Assert.AreEqual(4, c2.R);
            Assert.AreEqual(5, c2.I);
            Assert.AreEqual(4 * 4 + 5 * 5, c2.Norm);
            Assert.AreEqual(MultiPrecision<Pow2.N8>.Sqrt(4 * 4 + 5 * 5), c2.Magnitude);

            Assert.AreEqual(6, c3.R);
            Assert.AreEqual(0, c3.I);
        }

        [TestMethod()]
        public void DeconstructTest() {
            Complex<Pow2.N8> c1 = new(2, 3);

            (MultiPrecision<Pow2.N8> r, MultiPrecision<Pow2.N8> i) = c1;

            Assert.AreEqual(2, r);
            Assert.AreEqual(3, i);
        }

        [TestMethod()]
        public void ExponentTest() {
            Complex<Pow2.N8> c1 = new(2, 6);
            Complex<Pow2.N8> c2 = new(9, 1);

            Assert.AreEqual(2, c1.Exponent);
            Assert.AreEqual(3, c2.Exponent);
        }

        [TestMethod()]
        public void LdexpTest() {
            Complex<Pow2.N8> c1 = new(2, 6);

            Assert.AreEqual((8, 24), Complex<Pow2.N8>.Ldexp(c1, 2));
        }

        [TestMethod()]
        public void ToStringTest() {
            Complex<Pow2.N8> c1 = (2, 3);
            Complex<Pow2.N8> c2 = (2, 0);
            Complex<Pow2.N8> c3 = (2, -3);

            Complex<Pow2.N8> c4 = (0, 3);
            Complex<Pow2.N8> c5 = (0, 0);
            Complex<Pow2.N8> c6 = (0, -3);

            Complex<Pow2.N8> c7 = (-2, 3);
            Complex<Pow2.N8> c8 = (-2, 0);
            Complex<Pow2.N8> c9 = (-2, -3);

            Complex<Pow2.N8> c10 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6));
            Complex<Pow2.N8> c11 = (0, MultiPrecision<Pow2.N8>.Rcp(6));
            Complex<Pow2.N8> c12 = (MultiPrecision<Pow2.N8>.Rcp(3), 0);
            Complex<Pow2.N8> c13 = (0, 0);

            Complex<Pow2.N8> c14 = (MultiPrecision<Pow2.N8>.Rcp(3), -MultiPrecision<Pow2.N8>.Rcp(6));
            Complex<Pow2.N8> c15 = (-MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6));

            Assert.AreEqual("2+3i", c1.ToString());
            Assert.AreEqual("2", c2.ToString());
            Assert.AreEqual("2-3i", c3.ToString());

            Assert.AreEqual("3i", c4.ToString());
            Assert.AreEqual("0", c5.ToString());
            Assert.AreEqual("-3i", c6.ToString());

            Assert.AreEqual("-2+3i", c7.ToString());
            Assert.AreEqual("-2", c8.ToString());
            Assert.AreEqual("-2-3i", c9.ToString());

            Assert.AreEqual("0", Complex<Pow2.N8>.Zero.ToString());
            Assert.AreEqual(double.NaN.ToString(), Complex<Pow2.N8>.NaN.ToString());

            Assert.AreEqual("3.333e-1+1.667e-1i", $"{c10:e3}");
            Assert.AreEqual("1.667e-1i", $"{c11:e3}");
            Assert.AreEqual("3.333e-1", $"{c12:e3}");
            Assert.AreEqual("0", $"{c13:e3}");

            Assert.AreEqual("3.333e-1-1.667e-1i", $"{c14:e3}");
            Assert.AreEqual("-3.333e-1+1.667e-1i", $"{c15:e3}");
        }

        [TestMethod()]
        public void ConvertTest() {
            Complex<Pow2.N8> x = (1, 2);
            Complex<Pow2.N4> y = x.Convert<Pow2.N4>();

            Assert.AreEqual((1, 2), y);
        }
    }
}