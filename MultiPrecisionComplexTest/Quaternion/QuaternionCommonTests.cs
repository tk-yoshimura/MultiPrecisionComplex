using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionCommonTests {
        [TestMethod()]
        public void QuaternionTest() {
            Quaternion<Pow2.N8> c1 = new(2, 3, -1, 6);
            Quaternion<Pow2.N8> c2 = (4, 5, 7, -2);
            Quaternion<Pow2.N8> c3 = 6;

            Assert.AreEqual(2, c1.R);
            Assert.AreEqual(3, c1.I);
            Assert.AreEqual(-1, c1.J);
            Assert.AreEqual(6, c1.K);

            Assert.AreEqual(4, c2.R);
            Assert.AreEqual(5, c2.I);
            Assert.AreEqual(7, c2.J);
            Assert.AreEqual(-2, c2.K);
            Assert.AreEqual(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2, c2.SquareNorm);
            Assert.AreEqual(MultiPrecision<Pow2.N8>.Sqrt(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2), c2.Norm);

            Assert.AreEqual(6, c3.R);
            Assert.AreEqual(0, c3.I);
            Assert.AreEqual(0, c3.J);
            Assert.AreEqual(0, c3.K);

            Assert.AreEqual((3, -1, 6), c1.Vector);

            Assert.IsTrue((1 - c2.Normal.Norm) < 1e-30);
        }

        [TestMethod()]
        public void DeconstructTest() {
            Quaternion<Pow2.N8> c1 = new(2, 3, -1, 6);

            (MultiPrecision<Pow2.N8> r, MultiPrecision<Pow2.N8> i, MultiPrecision<Pow2.N8> j, MultiPrecision<Pow2.N8> k) = c1;

            Assert.AreEqual(2, r);
            Assert.AreEqual(3, i);
            Assert.AreEqual(-1, j);
            Assert.AreEqual(6, k);
        }

        [TestMethod()]
        public void ExponentTest() {
            Quaternion<Pow2.N8> c1 = new(2, 6, 0, 1);
            Quaternion<Pow2.N8> c2 = new(9, 1, 2, 3);
            Quaternion<Pow2.N8> c3 = new(2, 1, 16, 3);
            Quaternion<Pow2.N8> c4 = new(2, 1, 2, 34);

            Assert.AreEqual(2, c1.Exponent);
            Assert.AreEqual(3, c2.Exponent);
            Assert.AreEqual(4, c3.Exponent);
            Assert.AreEqual(5, c4.Exponent);
        }

        [TestMethod()]
        public void LdexpTest() {
            Quaternion<Pow2.N8> c1 = new(2, 6, 3, 1);

            Assert.AreEqual((8, 24, 12, 4), Quaternion<Pow2.N8>.Ldexp(c1, 2));
        }

        [TestMethod()]
        public void ToStringTest() {
            Quaternion<Pow2.N8> c1 = (2, 3, 0, 1);
            Quaternion<Pow2.N8> c2 = (2, 0, 1, 0);
            Quaternion<Pow2.N8> c3 = (2, -3, 0, 0);

            Quaternion<Pow2.N8> c4 = (0, 3, 1, 1);
            Quaternion<Pow2.N8> c5 = (0, 0, 0, 0);
            Quaternion<Pow2.N8> c6 = (0, -3, 0, 1);

            Quaternion<Pow2.N8> c7 = (-2, 3, 0, -1);
            Quaternion<Pow2.N8> c8 = (-2, 0, 0, 0);
            Quaternion<Pow2.N8> c9 = (-2, -3, -1, -1);

            Quaternion<Pow2.N8> c10 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c11 = (0, MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c12 = (0, 0, 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c13 = (0, 0, 0, 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c14 = (0, 0, 0, 0);
            Quaternion<Pow2.N8> c15 = (MultiPrecision<Pow2.N8>.Rcp(3), 0, 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c16 = (MultiPrecision<Pow2.N8>.Rcp(3), 0, 0, 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c17 = (MultiPrecision<Pow2.N8>.Rcp(3), 0, 0, 0);
            Quaternion<Pow2.N8> c18 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 0, 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c19 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 0, 0);
            Quaternion<Pow2.N8> c20 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), 0);
            Quaternion<Pow2.N8> c21 = (-MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c22 = (MultiPrecision<Pow2.N8>.Rcp(3), -MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c23 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), -1 - MultiPrecision<Pow2.N8>.Rcp(3), 1 + MultiPrecision<Pow2.N8>.Rcp(6));
            Quaternion<Pow2.N8> c24 = (MultiPrecision<Pow2.N8>.Rcp(3), MultiPrecision<Pow2.N8>.Rcp(6), 1 + MultiPrecision<Pow2.N8>.Rcp(3), -1 - MultiPrecision<Pow2.N8>.Rcp(6));

            Assert.AreEqual("2+3i+1k", c1.ToString());
            Assert.AreEqual("2+1j", c2.ToString());
            Assert.AreEqual("2-3i", c3.ToString());

            Assert.AreEqual("3i+1j+1k", c4.ToString());
            Assert.AreEqual("0", c5.ToString());
            Assert.AreEqual("-3i+1k", c6.ToString());

            Assert.AreEqual("-2+3i-1k", c7.ToString());
            Assert.AreEqual("-2", c8.ToString());
            Assert.AreEqual("-2-3i-1j-1k", c9.ToString());

            Assert.AreEqual("0", Quaternion<Pow2.N8>.Zero.ToString());
            Assert.AreEqual(double.NaN.ToString(), Quaternion<Pow2.N8>.NaN.ToString());

            Assert.AreEqual("3.333e-1+1.667e-1i+1.333e0j+1.167e0k", $"{c10:e3}");
            Assert.AreEqual("1.667e-1i+1.333e0j+1.167e0k", $"{c11:e3}");
            Assert.AreEqual("1.333e0j+1.167e0k", $"{c12:e3}");
            Assert.AreEqual("1.167e0k", $"{c13:e3}");
            Assert.AreEqual("0", $"{c14:e3}");
            Assert.AreEqual("3.333e-1+1.333e0j+1.167e0k", $"{c15:e3}");
            Assert.AreEqual("3.333e-1+1.167e0k", $"{c16:e3}");
            Assert.AreEqual("3.333e-1", $"{c17:e3}");
            Assert.AreEqual("3.333e-1+1.667e-1i+1.167e0k", $"{c18:e3}");
            Assert.AreEqual("3.333e-1+1.667e-1i", $"{c19:e3}");
            Assert.AreEqual("3.333e-1+1.667e-1i+1.333e0j", $"{c20:e3}");
            Assert.AreEqual("-3.333e-1+1.667e-1i+1.333e0j+1.167e0k", $"{c21:e3}");
            Assert.AreEqual("3.333e-1-1.667e-1i+1.333e0j+1.167e0k", $"{c22:e3}");
            Assert.AreEqual("3.333e-1+1.667e-1i-1.333e0j+1.167e0k", $"{c23:e3}");
            Assert.AreEqual("3.333e-1+1.667e-1i+1.333e0j-1.167e0k", $"{c24:e3}");
        }

        [TestMethod()]
        public void ConvertTest() {
            Quaternion<Pow2.N8> x = (1, 2, 3, 4);
            Quaternion<Pow2.N4> y = x.Convert<Pow2.N4>();

            Assert.AreEqual((1, 2, 3, 4), y);
        }
    }
}