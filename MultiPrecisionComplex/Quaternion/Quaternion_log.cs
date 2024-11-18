using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Log(Quaternion<N> q) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Norm;
            MultiPrecision<N> vnorm = VectorPart(q).Norm;

            if (IsZero(vnorm)) {
                return Complex<N>.Log(qnorm);
            }

            MultiPrecision<N> w = MultiPrecision<N>.Acos(q.R / qnorm) / vnorm;

            Quaternion<N> p = new(MultiPrecision<N>.Log(qnorm), w * q.I, w * q.J, w * q.K);

            return p;
        }
    }
}
