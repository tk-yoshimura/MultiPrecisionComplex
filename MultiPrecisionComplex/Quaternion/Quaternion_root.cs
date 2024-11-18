using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Sqrt(Quaternion<N> q) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Norm;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / 2;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Norm;
            if (IsNaN(vnormal)) {
                return Complex<N>.Sqrt(q.R);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * MultiPrecision<N>.Sqrt(qnorm);

            return r;
        }

        public static Quaternion<N> Cbrt(Quaternion<N> q) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Norm;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / 3;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Norm;
            if (IsNaN(vnormal)) {
                return MultiPrecision<N>.Cbrt(q.R);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * MultiPrecision<N>.Cbrt(qnorm);

            return r;
        }

        public static Quaternion<N> RootN(Quaternion<N> q, int n) {
            if (IsNaN(q)) {
                return NaN;
            }

            static MultiPrecision<N> root_n(MultiPrecision<N> x, int n) {
                return (x.Sign != Sign.Minus ? +1 : -1) * MultiPrecision<N>.Pow(MultiPrecision<N>.Abs(x), MultiPrecision<N>.Div(1, n));
            }

            MultiPrecision<N> qnorm = q.Norm;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / n;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Norm;
            if (IsNaN(vnormal)) {
                return ((n & 1) == 0) ? Complex<N>.RootN(q.R, n) : root_n(q.R, n);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * root_n(qnorm, n);

            return r;
        }
    }
}
