
using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> : IEquatable<Complex<N>> {

        public static bool IsNaN(Complex<N> c) => MultiPrecision<N>.IsNaN(c.R) || MultiPrecision<N>.IsNaN(c.I);

        public static bool IsFinite(Complex<N> c) => MultiPrecision<N>.IsFinite(c.R) && MultiPrecision<N>.IsFinite(c.I);

        public static bool IsZero(Complex<N> c) => MultiPrecision<N>.IsZero(c.R) && MultiPrecision<N>.IsZero(c.I);

        public static bool operator ==(Complex<N> a, Complex<N> b) {
            return a.R == b.R && a.I == b.I;
        }

        public static bool operator !=(Complex<N> a, Complex<N> b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            return (obj is not null && obj is Complex<N> c) && c == this;
        }
        public bool Equals(Complex<N> other) {
            return this == other;
        }

        public override int GetHashCode() {
            return R.GetHashCode() ^ I.GetHashCode();
        }
    }
}
