using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass]
    public partial class ComplexIOTests {
        [TestMethod]
        public void IOTest() {
            const string filename_bin = "c_iotest.bin";

            Complex<Pow2.N4> v = (MultiPrecision<Pow2.N4>.Pi, MultiPrecision<Pow2.N4>.E);

            using (BinaryWriter stream = new BinaryWriter(File.Open(filename_bin, FileMode.Create))) {
                stream.Write(v);
            }

            Complex<Pow2.N4> u;

            using (BinaryReader stream = new BinaryReader(File.OpenRead(filename_bin))) {
                u = stream.ReadComplex<Pow2.N4>();
            }

            Assert.AreEqual(v, u);

            File.Delete(filename_bin);
        }
    }
}
