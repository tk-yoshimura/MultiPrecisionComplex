using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Sin(Quaternion<N> q) {
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;
            MultiPrecision<N> w = MultiPrecision<N>.Cos(q.R) * MultiPrecision<N>.Sinhc(vnorm);

            Quaternion<N> p = new(MultiPrecision<N>.Sin(q.R) * MultiPrecision<N>.Cosh(vnorm), w * q.I, w * q.J, w * q.K);

            return p;
        }

        public static Quaternion<N> Cos(Quaternion<N> q) {
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;
            MultiPrecision<N> w = -MultiPrecision<N>.Sin(q.R) * MultiPrecision<N>.Sinhc(vnorm);

            Quaternion<N> p = new(MultiPrecision<N>.Cos(q.R) * MultiPrecision<N>.Cosh(vnorm), w * q.I, w * q.J, w * q.K);

            return p;
        }

        public static Quaternion<N> Tan(Quaternion<N> q) {
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;

            MultiPrecision<N> sinhc = MultiPrecision<N>.Sinhc(vnorm), cosh = MultiPrecision<N>.Cosh(vnorm);
            MultiPrecision<N> cos = MultiPrecision<N>.Cos(q.R), sin = MultiPrecision<N>.Sin(q.R);

            MultiPrecision<N> wcos = cos * sinhc, wsin = -sin * sinhc;

            Quaternion<N> qsin = new(sin * cosh, wcos * q.I, wcos * q.J, wcos * q.K);
            Quaternion<N> qcos = new(cos * cosh, wsin * q.I, wsin * q.J, wsin * q.K);

            return qsin / qcos;
        }
    }
}
