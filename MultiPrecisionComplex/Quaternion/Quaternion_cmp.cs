
using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static bool IsNaN(Quaternion<N> q)
            => MultiPrecision<N>.IsNaN(q.R) || MultiPrecision<N>.IsNaN(q.I) || MultiPrecision<N>.IsNaN(q.J) || MultiPrecision<N>.IsNaN(q.K);

        public static bool IsFinite(Quaternion<N> q)
            => MultiPrecision<N>.IsFinite(q.R) && MultiPrecision<N>.IsFinite(q.I) && MultiPrecision<N>.IsFinite(q.J) && MultiPrecision<N>.IsFinite(q.K);

        public static bool IsZero(Quaternion<N> q)
            => MultiPrecision<N>.IsZero(q.R) && MultiPrecision<N>.IsZero(q.I) && MultiPrecision<N>.IsZero(q.J) && MultiPrecision<N>.IsZero(q.K);

        public static bool operator ==(Quaternion<N> a, Quaternion<N> b) {
            return a.R == b.R && a.I == b.I && a.J == b.J && a.K == b.K;
        }

        public static bool operator !=(Quaternion<N> a, Quaternion<N> b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            return (obj is not null && obj is Quaternion<N> q) && q == this;
        }

        public override int GetHashCode() {
            return R.GetHashCode() ^ I.GetHashCode();
        }
    }
}
