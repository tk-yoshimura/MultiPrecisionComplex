using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> FromAxisAngle((MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) axis, MultiPrecision<N> angle) {
            MultiPrecision<N> half_angle = angle / 2;
            MultiPrecision<N> c = MultiPrecision<N>.Cos(half_angle), s = MultiPrecision<N>.Sin(half_angle);

            return new Quaternion<N>(c, s * axis.x, s * axis.y, s * axis.z);
        }

        public static Quaternion<N> FromYawPitchRoll(MultiPrecision<N> yaw, MultiPrecision<N> pitch, MultiPrecision<N> roll) {
            MultiPrecision<N> half_yaw = yaw / 2, half_pitch = pitch / 2, half_roll = roll / 2;

            MultiPrecision<N> cy = MultiPrecision<N>.Cos(half_yaw), sy = MultiPrecision<N>.Sin(half_yaw);
            MultiPrecision<N> cp = MultiPrecision<N>.Cos(half_pitch), sp = MultiPrecision<N>.Sin(half_pitch);
            MultiPrecision<N> cr = MultiPrecision<N>.Cos(half_roll), sr = MultiPrecision<N>.Sin(half_roll);

            return new Quaternion<N>(
                cy * cp * cr + sy * sp * sr,
                cy * sp * cr + sy * cp * sr,
                sy * cp * cr - cy * sp * sr,
                cy * cp * sr - sy * sp * cr
            );
        }

        public static Quaternion<N> VectorPart(Quaternion<N> q) {
            return new Quaternion<N>(MultiPrecision<N>.Zero, q.I, q.J, q.K);
        }

        public static Quaternion<N> RealPart(Quaternion<N> q) {
            return new Quaternion<N>(q.R, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

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

        public static Quaternion<N> Exp(Quaternion<N> q) {
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;
            MultiPrecision<N> w = MultiPrecision<N>.Sinc(vnorm, normalized: false);

            Quaternion<N> p = new Quaternion<N>(MultiPrecision<N>.Cos(vnorm), w * q.I, w * q.J, w * q.K) * MultiPrecision<N>.Exp(q.R);

            return p;
        }

        public static Quaternion<N> Log(Quaternion<N> q) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Magnitude;
            MultiPrecision<N> vnorm = VectorPart(q).Magnitude;

            if (IsZero(vnorm)) {
                return Complex<N>.Log(qnorm);
            }

            MultiPrecision<N> w = MultiPrecision<N>.Acos(q.R / qnorm) / vnorm;

            Quaternion<N> p = new(MultiPrecision<N>.Log(qnorm), w * q.I, w * q.J, w * q.K);

            return p;
        }

        public static Quaternion<N> Pow(Quaternion<N> q, MultiPrecision<N> p) {
            if (IsNaN(q) || MultiPrecision<N>.IsNaN(p)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Magnitude;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) * p;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Magnitude;
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

            MultiPrecision<N> qnorm = q.Magnitude;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) * n;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Magnitude;
            if (IsNaN(vnormal)) {
                return MultiPrecision<N>.Pow(q.R, n);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * MultiPrecision<N>.Pow(qnorm, n);

            return r;
        }

        public static Quaternion<N> Sqrt(Quaternion<N> q) {
            if (IsNaN(q)) {
                return NaN;
            }

            MultiPrecision<N> qnorm = q.Magnitude;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / 2;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Magnitude;
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

            MultiPrecision<N> qnorm = q.Magnitude;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / 3;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Magnitude;
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

            MultiPrecision<N> qnorm = q.Magnitude;

            MultiPrecision<N> phi = MultiPrecision<N>.Acos(q.R / qnorm) / n;

            Quaternion<N> vec = VectorPart(q);
            Quaternion<N> vnormal = vec / vec.Magnitude;
            if (IsNaN(vnormal)) {
                return ((n & 1) == 0) ? Complex<N>.RootN(q.R, n) : root_n(q.R, n);
            }

            MultiPrecision<N> c = MultiPrecision<N>.Cos(phi), s = MultiPrecision<N>.Sin(phi);

            Quaternion<N> r = new Quaternion<N>(c, s * vnormal.I, s * vnormal.J, s * vnormal.K) * root_n(qnorm, n);

            return r;
        }
    }
}
