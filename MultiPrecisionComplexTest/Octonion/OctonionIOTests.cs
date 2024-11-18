using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass]
    public partial class OctonionIOTests {
        [TestMethod]
        public void IOTest() {
            const string filename_bin = "o_iotest.bin";
            Octonion<Pow2.N4> v = (
                MultiPrecision<Pow2.N4>.Pi, MultiPrecision<Pow2.N4>.E, MultiPrecision<Pow2.N4>.RcpPi, 1 / MultiPrecision<Pow2.N4>.E,
                -MultiPrecision<Pow2.N4>.Pi, -MultiPrecision<Pow2.N4>.E, -MultiPrecision<Pow2.N4>.RcpPi, -1 / MultiPrecision<Pow2.N4>.E
            );

            using (BinaryWriter stream = new BinaryWriter(File.Open(filename_bin, FileMode.Create))) {
                stream.Write(v);
            }

            Octonion<Pow2.N4> u;

            using (BinaryReader stream = new BinaryReader(File.OpenRead(filename_bin))) {
                u = stream.ReadOctonion<Pow2.N4>();
            }

            Assert.AreEqual(v, u);

            File.Delete(filename_bin);
        }
    }
}
