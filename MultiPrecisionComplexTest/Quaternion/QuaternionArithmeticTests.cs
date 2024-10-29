using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    using NQuaternion = System.Numerics.Quaternion;

    [TestClass()]
    public class QuaternionArithmeticTests {
        [TestMethod()]
        public void AddTest() {
            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a + b;
                    NQuaternion nc = (NQuaternion)a + (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                    Quaternion<Pow2.N8> c = a + b;
                    NQuaternion nc = (NQuaternion)a + new NQuaternion(0, 0, 0, (float)b);

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a + b;
                    NQuaternion nc = new NQuaternion(0, 0, 0, (float)a) + (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void SubTest() {
            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a - b;
                    NQuaternion nc = (NQuaternion)a - (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                    Quaternion<Pow2.N8> c = a - b;
                    NQuaternion nc = (NQuaternion)a - new NQuaternion(0, 0, 0, (float)b);

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a - b;
                    NQuaternion nc = new NQuaternion(0, 0, 0, (float)a) - (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }
        }

        [TestMethod()]
        public void MulTest() {
            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a * b;
                    NQuaternion nc = (NQuaternion)a * (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                    Quaternion<Pow2.N8> c = a * b;
                    NQuaternion nc = (NQuaternion)a * new NQuaternion(0, 0, 0, (float)b);

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a * b;
                    NQuaternion nc = new NQuaternion(0, 0, 0, (float)a) * (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-7);
                }
            }

            Quaternion<Pow2.N8> q = (3, -9, 2, 4);

            QuaternionAssert<Pow2.N8>.AreEqual(q * (2d, 0, 0, 0), q * 2, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual(q * (2d, -3, 0, 0), q * (2d, -3), 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual(q * (2d, -3, 5, -7), q * (2d, -3, 5, -7), 1e-30);

            QuaternionAssert<Pow2.N8>.AreEqual((2d, 0, 0, 0) * q, 2 * q, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual((2d, -3, 0, 0) * q, (2d, -3) * q, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual((2d, -3, 5, -7) * q, (2d, -3, 5, -7) * q, 1e-30);
        }

        [TestMethod()]
        public void DivTest() {
            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a / b;
                    NQuaternion nc = (NQuaternion)a / (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                    QuaternionAssert<Pow2.N8>.AreEqual(a, c * b, 1e-30);
                }
            }

            foreach (Quaternion<Pow2.N8> a in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                foreach (MultiPrecision<Pow2.N8> b in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                    Quaternion<Pow2.N8> c = a / b;
                    NQuaternion nc = (NQuaternion)a / new NQuaternion(0, 0, 0, (float)b);

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                }
            }

            foreach (MultiPrecision<Pow2.N8> a in new[] { 1, 2, 3, 4, -1, -3, -5 }) {
                foreach (Quaternion<Pow2.N8> b in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                    Quaternion<Pow2.N8> c = a / b;
                    NQuaternion nc = new NQuaternion(0, 0, 0, (float)a) / (NQuaternion)b;

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                }
            }

            Quaternion<Pow2.N8> q = (3, -9, 2, 4);

            QuaternionAssert<Pow2.N8>.AreEqual(q / (2d, 0, 0, 0), q / 2, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual(q / (2d, -3, 0, 0), q / (2d, -3), 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual(q / (2d, -3, 5, -7), q / (2d, -3, 5, -7), 1e-30);

            QuaternionAssert<Pow2.N8>.AreEqual((2d, 0, 0, 0) / q, 2 / q, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual((2d, -3, 0, 0) / q, (2d, -3) / q, 1e-30);
            QuaternionAssert<Pow2.N8>.AreEqual((2d, -3, 5, -7) / q, (2d, -3, 5, -7) / q, 1e-30);
        }

        [TestMethod()]
        public void FromAxisAngleTest() {
            foreach ((double x, double y, double z) in new[] { (1, 2, 3), (2, -4, 5), (4, 2, 1) }) {
                foreach (double theta in new[] { 0.25, 0.5, 0.75 }) {

                    Quaternion<Pow2.N8> c = Quaternion<Pow2.N8>.FromAxisAngle((x, y, z), theta);
                    NQuaternion nc = NQuaternion.CreateFromAxisAngle(new System.Numerics.Vector3((float)x, (float)y, (float)z), (float)theta);

                    QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
                }
            }
        }

        [TestMethod()]
        public void FromYawPitchRollTest() {
            foreach ((double yaw, double pitch, double roll) in new[] { (1, 2, 3), (2, -4, 5), (4, 2, 1) }) {
                Quaternion<Pow2.N8> c = Quaternion<Pow2.N8>.FromYawPitchRoll(yaw, pitch, roll);
                NQuaternion nc = NQuaternion.CreateFromYawPitchRoll((float)yaw, (float)pitch, (float)roll);

                QuaternionAssert<Pow2.N8>.AreEqual(nc, c, 1e-6);
            }
        }


        [TestMethod()]
        public void InverseTest() {
            foreach (Quaternion<Pow2.N8> q in new[] { (1, 2, 3, 4), (2, 5, -2, 6), (6, -3, 1, 2), (7, -4, 5, 1), (3, -9, 2, 4), (7, 1, -3, 2), (-3, 5, 2, -1) }) {
                Quaternion<Pow2.N8> s = Quaternion<Pow2.N8>.Inverse(q);

                QuaternionAssert<Pow2.N8>.AreEqual(1, s * q, 1e-24);
            }
        }
    }
}
