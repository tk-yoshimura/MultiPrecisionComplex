using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Octonion<N> : IEquatable<Octonion<N>> {

        public static bool IsNaN(Octonion<N> o)
            => MultiPrecision<N>.IsNaN(o.R) || MultiPrecision<N>.IsNaN(o.I) || MultiPrecision<N>.IsNaN(o.J) || MultiPrecision<N>.IsNaN(o.K) ||
               MultiPrecision<N>.IsNaN(o.W) || MultiPrecision<N>.IsNaN(o.X) || MultiPrecision<N>.IsNaN(o.Y) || MultiPrecision<N>.IsNaN(o.Z);

        public static bool IsFinite(Octonion<N> o)
            => MultiPrecision<N>.IsFinite(o.R) && MultiPrecision<N>.IsFinite(o.I) && MultiPrecision<N>.IsFinite(o.J) && MultiPrecision<N>.IsFinite(o.K) &&
               MultiPrecision<N>.IsFinite(o.W) && MultiPrecision<N>.IsFinite(o.X) && MultiPrecision<N>.IsFinite(o.Y) && MultiPrecision<N>.IsFinite(o.Z);

        public static bool IsZero(Octonion<N> o)
            => MultiPrecision<N>.IsZero(o.R) && MultiPrecision<N>.IsZero(o.I) && MultiPrecision<N>.IsZero(o.J) && MultiPrecision<N>.IsZero(o.K) &&
               MultiPrecision<N>.IsZero(o.W) && MultiPrecision<N>.IsZero(o.X) && MultiPrecision<N>.IsZero(o.Y) && MultiPrecision<N>.IsZero(o.Z);

        public static bool operator ==(Octonion<N> a, Octonion<N> b) {
            return a.R == b.R && a.I == b.I && a.J == b.J && a.K == b.K && a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Octonion<N> a, Octonion<N> b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            return (obj is not null && obj is Octonion<N> q) && q == this;
        }

        public bool Equals(Octonion<N> other) {
            return this == other;
        }

        public override int GetHashCode() {
            return R.GetHashCode() ^ I.GetHashCode();
        }

    }
}
