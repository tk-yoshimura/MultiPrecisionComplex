using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Pow(Quaternion<N> q, MultiPrecision<N> p) {
            if (IsNaN(q) || MultiPrecision<N>.IsNaN(p)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Norm;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) * p;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Norm;
            if (IsNaN(vnormal)) {
                return MultiPrecision<N>.Pow(q.R, p);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * MultiPrecision<N>.Pow(qnorm, p);

            return r;
        }

        public static Quaternion<N> Pow(Quaternion<N> q, long n) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Norm;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) * n;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Norm;
            if (IsNaN(vnormal)) {
                return MultiPrecision<N>.Pow(q.R, n);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * MultiPrecision<N>.Pow(qnorm, n);

            return r;
        }
    }
}
