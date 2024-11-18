using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class OctonionCommonTests {
        [TestMethod()]
        public void OctonionTest() {
            Octonion<Pow2.N4> c1 = new(2, 3, -1, 6, 4, 7, -2, 8);
            Octonion<Pow2.N4> c2 = (4, 5, 7, -2, 3, -4, 1, -3);
            Octonion<Pow2.N4> c3 = 6;
            Octonion<Pow2.N4> c4 = c2.Conj;

            Assert.AreEqual(2, c1.R);
            Assert.AreEqual(3, c1.I);
            Assert.AreEqual(-1, c1.J);
            Assert.AreEqual(6, c1.K);
            Assert.AreEqual(4, c1.W);
            Assert.AreEqual(7, c1.X);
            Assert.AreEqual(-2, c1.Y);
            Assert.AreEqual(8, c1.Z);

            Assert.AreEqual(4, c2.R);
            Assert.AreEqual(5, c2.I);
            Assert.AreEqual(7, c2.J);
            Assert.AreEqual(-2, c2.K);
            Assert.AreEqual(3, c2.W);
            Assert.AreEqual(-4, c2.X);
            Assert.AreEqual(1, c2.Y);
            Assert.AreEqual(-3, c2.Z);

            Assert.AreEqual(4, c4.R);
            Assert.AreEqual(-5, c4.I);
            Assert.AreEqual(-7, c4.J);
            Assert.AreEqual(2, c4.K);
            Assert.AreEqual(-3, c4.W);
            Assert.AreEqual(4, c4.X);
            Assert.AreEqual(-1, c4.Y);
            Assert.AreEqual(3, c4.Z);

            Assert.AreEqual(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2 + 3 * 3 + 4 * 4 + 1 * 1 + 3 * 3, c2.SquareNorm);
            Assert.AreEqual(MultiPrecision<Pow2.N4>.Sqrt(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2 + 3 * 3 + 4 * 4 + 1 * 1 + 3 * 3), c2.Norm);
            Assert.AreEqual(Octonion<Pow2.N4>.Ldexp(MultiPrecision<Pow2.N4>.Sqrt(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2 + 3 * 3 + 4 * 4 + 1 * 1 + 3 * 3), 800), Octonion<Pow2.N4>.Ldexp(c2, 800).Norm);
            Assert.AreEqual(Octonion<Pow2.N4>.Ldexp(MultiPrecision<Pow2.N4>.Sqrt(4 * 4 + 5 * 5 + 7 * 7 + 2 * 2 + 3 * 3 + 4 * 4 + 1 * 1 + 3 * 3), -800), Octonion<Pow2.N4>.Ldexp(c2, -800).Norm);
            Assert.AreEqual(0d, Octonion<Pow2.N4>.Zero.Norm);

            Assert.AreEqual(6, c3.R);
            Assert.AreEqual(0, c3.I);
            Assert.AreEqual(0, c3.J);
            Assert.AreEqual(0, c3.K);
            Assert.AreEqual(0, c3.W);
            Assert.AreEqual(0, c3.X);
            Assert.AreEqual(0, c3.Y);
            Assert.AreEqual(0, c3.Z);

            Assert.IsTrue((1 - c2.Normal.Norm) < 1e-30);
        }

        [TestMethod()]
        public void DeconstructTest() {
            Octonion<Pow2.N4> c1 = new(2, 3, -1, 6, 4, 7, -2, 8);

            (MultiPrecision<Pow2.N4> r, MultiPrecision<Pow2.N4> s, MultiPrecision<Pow2.N4> t, MultiPrecision<Pow2.N4> u, MultiPrecision<Pow2.N4> w, MultiPrecision<Pow2.N4> x, MultiPrecision<Pow2.N4> y, MultiPrecision<Pow2.N4> z) = c1;

            Assert.AreEqual(2, r);
            Assert.AreEqual(3, s);
            Assert.AreEqual(-1, t);
            Assert.AreEqual(6, u);
            Assert.AreEqual(4, w);
            Assert.AreEqual(7, x);
            Assert.AreEqual(-2, y);
            Assert.AreEqual(8, z);
        }

        [TestMethod()]
        public void ILogBTest() {
            Octonion<Pow2.N4> c1 = new(2, 6, 0, 1, -2, -1, 0, 5);
            Octonion<Pow2.N4> c2 = new(9, 1, 2, 3, -2, -3, -7, 1);
            Octonion<Pow2.N4> c3 = new(2, 1, 16, 3, 3, -2, 1, 7);
            Octonion<Pow2.N4> c4 = new(2, 1, 2, 34, -32, -3, -6, -8);

            Assert.AreEqual(2, c1.Exponent);
            Assert.AreEqual(3, c2.Exponent);
            Assert.AreEqual(4, c3.Exponent);
            Assert.AreEqual(5, c4.Exponent);
        }

        [TestMethod()]
        public void LdexpTest() {
            Octonion<Pow2.N4> c1 = new(2, 6, 3, 1, -2, -8, -7, 1);

            Assert.AreEqual((8, 24, 12, 4, -8, -32, -28, 4), Octonion<Pow2.N4>.Ldexp(c1, 2));
        }

        [TestMethod()]
        public void ToStringTest() {
            Octonion<Pow2.N4> c1 = (2, 3, 0, 1, 0, 0, 0, 0);
            Octonion<Pow2.N4> c2 = (2, 0, 1, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c3 = (2, -3, 0, 0, 0, 0, 0, 0);

            Octonion<Pow2.N4> c4 = (0, 3, 1, 1, 0, 0, 0, 0);
            Octonion<Pow2.N4> c5 = (0, 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c6 = (0, -3, 0, 1, 0, 0, 0, 0);

            Octonion<Pow2.N4> c7 = (-2, 3, 0, -1, 0, 0, 0, 0);
            Octonion<Pow2.N4> c8 = (-2, 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c9 = (-2, -3, -1, -1, 0, 0, 0, 0);

            Octonion<Pow2.N4> c10 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c11 = (0, MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c12 = (0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c13 = (0, 0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c14 = (0, 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c15 = (MultiPrecision<Pow2.N4>.Rcp(3), 0, 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c16 = (MultiPrecision<Pow2.N4>.Rcp(3), 0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c17 = (MultiPrecision<Pow2.N4>.Rcp(3), 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c18 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c19 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c20 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> c21 = (-MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c22 = (MultiPrecision<Pow2.N4>.Rcp(3), -MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c23 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), -1 - MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);
            Octonion<Pow2.N4> c24 = (MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), -1 - MultiPrecision<Pow2.N4>.Rcp(6), 0, 0, 0, 0);

            Assert.AreEqual("2+3i+1k", c1.ToString());
            Assert.AreEqual("2+1j", c2.ToString());
            Assert.AreEqual("2-3i", c3.ToString());

            Assert.AreEqual("3i+1j+1k", c4.ToString());
            Assert.AreEqual("0", c5.ToString());
            Assert.AreEqual("-3i+1k", c6.ToString());

            Assert.AreEqual("-2+3i-1k", c7.ToString());
            Assert.AreEqual("-2", c8.ToString());
            Assert.AreEqual("-2-3i-1j-1k", c9.ToString());

            Assert.AreEqual("0", Octonion<Pow2.N4>.Zero.ToString());
            Assert.AreEqual(double.NaN.ToString(), Octonion<Pow2.N4>.NaN.ToString());

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

            Octonion<Pow2.N4> d1 = (0, 0, 0, 0, 2, 3, 0, 1);
            Octonion<Pow2.N4> d2 = (0, 0, 0, 0, 2, 0, 1, 0);
            Octonion<Pow2.N4> d3 = (0, 0, 0, 0, 2, -3, 0, 0);

            Octonion<Pow2.N4> d4 = (0, 0, 0, 0, 0, 3, 1, 1);
            Octonion<Pow2.N4> d5 = (0, 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> d6 = (0, 0, 0, 0, 0, -3, 0, 1);

            Octonion<Pow2.N4> d7 = (0, 0, 0, 0, -2, 3, 0, -1);
            Octonion<Pow2.N4> d8 = (0, 0, 0, 0, -2, 0, 0, 0);
            Octonion<Pow2.N4> d9 = (0, 0, 0, 0, -2, -3, -1, -1);

            Octonion<Pow2.N4> d10 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d11 = (0, 0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d12 = (0, 0, 0, 0, 0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d13 = (0, 0, 0, 0, 0, 0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d14 = (0, 0, 0, 0, 0, 0, 0, 0);
            Octonion<Pow2.N4> d15 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), 0, 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d16 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), 0, 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d17 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), 0, 0, 0);
            Octonion<Pow2.N4> d18 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 0, 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d19 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 0, 0);
            Octonion<Pow2.N4> d20 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 0);
            Octonion<Pow2.N4> d21 = (0, 0, 0, 0, -MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d22 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), -MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d23 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), -1 - MultiPrecision<Pow2.N4>.Rcp(3), 1 + MultiPrecision<Pow2.N4>.Rcp(6));
            Octonion<Pow2.N4> d24 = (0, 0, 0, 0, MultiPrecision<Pow2.N4>.Rcp(3), MultiPrecision<Pow2.N4>.Rcp(6), 1 + MultiPrecision<Pow2.N4>.Rcp(3), -1 - MultiPrecision<Pow2.N4>.Rcp(6));

            Assert.AreEqual("2w+3x+1z", d1.ToString());
            Assert.AreEqual("2w+1y", d2.ToString());
            Assert.AreEqual("2w-3x", d3.ToString());

            Assert.AreEqual("3x+1y+1z", d4.ToString());
            Assert.AreEqual("0", d5.ToString());
            Assert.AreEqual("-3x+1z", d6.ToString());

            Assert.AreEqual("-2w+3x-1z", d7.ToString());
            Assert.AreEqual("-2w", d8.ToString());
            Assert.AreEqual("-2w-3x-1y-1z", d9.ToString());

            Assert.AreEqual("0", Octonion<Pow2.N4>.Zero.ToString());
            Assert.AreEqual(double.NaN.ToString(), Octonion<Pow2.N4>.NaN.ToString());

            Assert.AreEqual("3.333e-1w+1.667e-1x+1.333e0y+1.167e0z", $"{d10:e3}");
            Assert.AreEqual("1.667e-1x+1.333e0y+1.167e0z", $"{d11:e3}");
            Assert.AreEqual("1.333e0y+1.167e0z", $"{d12:e3}");
            Assert.AreEqual("1.167e0z", $"{d13:e3}");
            Assert.AreEqual("0", $"{d14:e3}");
            Assert.AreEqual("3.333e-1w+1.333e0y+1.167e0z", $"{d15:e3}");
            Assert.AreEqual("3.333e-1w+1.167e0z", $"{d16:e3}");
            Assert.AreEqual("3.333e-1w", $"{d17:e3}");
            Assert.AreEqual("3.333e-1w+1.667e-1x+1.167e0z", $"{d18:e3}");
            Assert.AreEqual("3.333e-1w+1.667e-1x", $"{d19:e3}");
            Assert.AreEqual("3.333e-1w+1.667e-1x+1.333e0y", $"{d20:e3}");
            Assert.AreEqual("-3.333e-1w+1.667e-1x+1.333e0y+1.167e0z", $"{d21:e3}");
            Assert.AreEqual("3.333e-1w-1.667e-1x+1.333e0y+1.167e0z", $"{d22:e3}");
            Assert.AreEqual("3.333e-1w+1.667e-1x-1.333e0y+1.167e0z", $"{d23:e3}");
            Assert.AreEqual("3.333e-1w+1.667e-1x+1.333e0y-1.167e0z", $"{d24:e3}");
        }
    }
}