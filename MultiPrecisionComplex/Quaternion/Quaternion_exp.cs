using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Exp(Quaternion<N> q) {
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;
            MultiPrecision<N> w = MultiPrecision<N>.Sinc(vnorm, normalized: false);

            Quaternion<N> p = new Quaternion<N>(MultiPrecision<N>.Cos(vnorm), w * q.I, w * q.J, w * q.K) * MultiPrecision<N>.Exp(q.R);

            return p;
        }
    }
}
