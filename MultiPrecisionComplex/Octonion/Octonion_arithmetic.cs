using MultiPrecision;
using System.Numerics;

namespace MultiPrecisionComplex {

    public partial class Octonion<N> :
        IAdditionOperators<Octonion<N>, Octonion<N>, Octonion<N>>,
        ISubtractionOperators<Octonion<N>, Octonion<N>, Octonion<N>>,
        IMultiplyOperators<Octonion<N>, Octonion<N>, Octonion<N>>,
        IDivisionOperators<Octonion<N>, Octonion<N>, Octonion<N>>,

        IUnaryPlusOperators<Octonion<N>, Octonion<N>>,
        IUnaryNegationOperators<Octonion<N>, Octonion<N>>,

        IEqualityOperators<Octonion<N>, Octonion<N>, bool> {

        public static Octonion<N> operator +(Octonion<N> o) {
            return o;
        }

        public static Octonion<N> operator -(Octonion<N> o) {
            return new(-o.R, -o.I, -o.J, -o.K, -o.W, -o.X, -o.Y, -o.Z);
        }

        public static Octonion<N> operator +(Octonion<N> a, Octonion<N> b) {
            return new(a.R + b.R, a.I + b.I, a.J + b.J, a.K + b.K, a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Octonion<N> operator +(Octonion<N> a, MultiPrecision<N> b) {
            return new(a.R + b, a.I, a.J, a.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator +(Octonion<N> a, Complex<N> b) {
            return new(a.R + b.R, a.I + b.I, a.J, a.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator +(Octonion<N> a, Quaternion<N> b) {
            return new(a.R + b.R, a.I + b.I, a.J + b.J, a.K + b.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator +(MultiPrecision<N> a, Octonion<N> b) {
            return new(a + b.R, b.I, b.J, b.K, b.W, b.X, b.Y, b.Z);
        }

        public static Octonion<N> operator +(Complex<N> a, Octonion<N> b) {
            return new(a.R + b.R, a.I + b.I, b.J, b.K, b.W, b.X, b.Y, b.Z);
        }

        public static Octonion<N> operator +(Quaternion<N> a, Octonion<N> b) {
            return new(a.R + b.R, a.I + b.I, a.J + b.J, a.K + b.K, b.W, b.X, b.Y, b.Z);
        }

        public static Octonion<N> operator -(Octonion<N> a, Octonion<N> b) {
            return new(a.R - b.R, a.I - b.I, a.J - b.J, a.K - b.K, a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Octonion<N> operator -(Octonion<N> a, MultiPrecision<N> b) {
            return new(a.R - b, a.I, a.J, a.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator -(Octonion<N> a, Complex<N> b) {
            return new(a.R - b.R, a.I - b.I, a.J, a.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator -(Octonion<N> a, Quaternion<N> b) {
            return new(a.R - b.R, a.I - b.I, a.J - b.J, a.K - b.K, a.W, a.X, a.Y, a.Z);
        }

        public static Octonion<N> operator -(MultiPrecision<N> a, Octonion<N> b) {
            return new(a - b.R, -b.I, -b.J, -b.K, -b.W, -b.X, -b.Y, -b.Z);
        }

        public static Octonion<N> operator -(Complex<N> a, Octonion<N> b) {
            return new(a.R - b.R, a.I - b.I, -b.J, -b.K, -b.W, -b.X, -b.Y, -b.Z);
        }

        public static Octonion<N> operator -(Quaternion<N> a, Octonion<N> b) {
            return new(a.R - b.R, a.I - b.I, a.J - b.J, a.K - b.K, -b.W, -b.X, -b.Y, -b.Z);
        }

        public static Octonion<N> operator *(Octonion<N> a, Octonion<N> b) {
            MultiPrecision<N> r = a.R * b.R - a.I * b.I - a.J * b.J - a.K * b.K - a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
            MultiPrecision<N> i = a.R * b.I + a.I * b.R + a.J * b.K - a.K * b.J + a.W * b.X - a.X * b.W - a.Y * b.Z + a.Z * b.Y;
            MultiPrecision<N> j = a.R * b.J - a.I * b.K + a.J * b.R + a.K * b.I + a.W * b.Y + a.X * b.Z - a.Y * b.W - a.Z * b.X;
            MultiPrecision<N> k = a.R * b.K + a.I * b.J - a.J * b.I + a.K * b.R + a.W * b.Z - a.X * b.Y + a.Y * b.X - a.Z * b.W;
            MultiPrecision<N> w = a.R * b.W - a.I * b.X - a.J * b.Y - a.K * b.Z + a.W * b.R + a.X * b.I + a.Y * b.J + a.Z * b.K;
            MultiPrecision<N> x = a.R * b.X + a.I * b.W - a.J * b.Z + a.K * b.Y - a.W * b.I + a.X * b.R - a.Y * b.K + a.Z * b.J;
            MultiPrecision<N> y = a.R * b.Y + a.I * b.Z + a.J * b.W - a.K * b.X - a.W * b.J + a.X * b.K + a.Y * b.R - a.Z * b.I;
            MultiPrecision<N> z = a.R * b.Z - a.I * b.Y + a.J * b.X + a.K * b.W - a.W * b.K - a.X * b.J + a.Y * b.I + a.Z * b.R;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(Octonion<N> a, MultiPrecision<N> b) {
            MultiPrecision<N> r = a.R * b;
            MultiPrecision<N> i = a.I * b;
            MultiPrecision<N> j = a.J * b;
            MultiPrecision<N> k = a.K * b;
            MultiPrecision<N> w = a.W * b;
            MultiPrecision<N> x = a.X * b;
            MultiPrecision<N> y = a.Y * b;
            MultiPrecision<N> z = a.Z * b;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(MultiPrecision<N> a, Octonion<N> b) {
            MultiPrecision<N> r = a * b.R;
            MultiPrecision<N> i = a * b.I;
            MultiPrecision<N> j = a * b.J;
            MultiPrecision<N> k = a * b.K;
            MultiPrecision<N> w = a * b.W;
            MultiPrecision<N> x = a * b.X;
            MultiPrecision<N> y = a * b.Y;
            MultiPrecision<N> z = a * b.Z;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(Octonion<N> a, Complex<N> b) {
            MultiPrecision<N> r = a.R * b.R - a.I * b.I;
            MultiPrecision<N> i = a.R * b.I + a.I * b.R;
            MultiPrecision<N> j = a.J * b.R + a.K * b.I;
            MultiPrecision<N> k = -a.J * b.I + a.K * b.R;
            MultiPrecision<N> w = a.W * b.R + a.X * b.I;
            MultiPrecision<N> x = -a.W * b.I + a.X * b.R;
            MultiPrecision<N> y = a.Y * b.R - a.Z * b.I;
            MultiPrecision<N> z = a.Y * b.I + a.Z * b.R;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(Complex<N> a, Octonion<N> b) {
            MultiPrecision<N> r = a.R * b.R - a.I * b.I;
            MultiPrecision<N> i = a.R * b.I + a.I * b.R;
            MultiPrecision<N> j = a.R * b.J - a.I * b.K;
            MultiPrecision<N> k = a.R * b.K + a.I * b.J;
            MultiPrecision<N> w = a.R * b.W - a.I * b.X;
            MultiPrecision<N> x = a.R * b.X + a.I * b.W;
            MultiPrecision<N> y = a.R * b.Y + a.I * b.Z;
            MultiPrecision<N> z = a.R * b.Z - a.I * b.Y;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(Octonion<N> a, Quaternion<N> b) {
            MultiPrecision<N> r = a.R * b.R - a.I * b.I - a.J * b.J - a.K * b.K;
            MultiPrecision<N> i = a.R * b.I + a.I * b.R + a.J * b.K - a.K * b.J;
            MultiPrecision<N> j = a.R * b.J - a.I * b.K + a.J * b.R + a.K * b.I;
            MultiPrecision<N> k = a.R * b.K + a.I * b.J - a.J * b.I + a.K * b.R;
            MultiPrecision<N> w = +a.W * b.R + a.X * b.I + a.Y * b.J + a.Z * b.K;
            MultiPrecision<N> x = -a.W * b.I + a.X * b.R - a.Y * b.K + a.Z * b.J;
            MultiPrecision<N> y = -a.W * b.J + a.X * b.K + a.Y * b.R - a.Z * b.I;
            MultiPrecision<N> z = -a.W * b.K - a.X * b.J + a.Y * b.I + a.Z * b.R;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator *(Quaternion<N> a, Octonion<N> b) {
            MultiPrecision<N> r = a.R * b.R - a.I * b.I - a.J * b.J - a.K * b.K;
            MultiPrecision<N> i = a.R * b.I + a.I * b.R + a.J * b.K - a.K * b.J;
            MultiPrecision<N> j = a.R * b.J - a.I * b.K + a.J * b.R + a.K * b.I;
            MultiPrecision<N> k = a.R * b.K + a.I * b.J - a.J * b.I + a.K * b.R;
            MultiPrecision<N> w = a.R * b.W - a.I * b.X - a.J * b.Y - a.K * b.Z;
            MultiPrecision<N> x = a.R * b.X + a.I * b.W - a.J * b.Z + a.K * b.Y;
            MultiPrecision<N> y = a.R * b.Y + a.I * b.Z + a.J * b.W - a.K * b.X;
            MultiPrecision<N> z = a.R * b.Z - a.I * b.Y + a.J * b.X + a.K * b.W;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(Octonion<N> a, Octonion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> n = 1d / b.SquareNorm;

            MultiPrecision<N> r = (+a.R * b.R + a.I * b.I + a.J * b.J + a.K * b.K + a.W * b.W + a.X * b.X + a.Y * b.Y + a.Z * b.Z) * n;
            MultiPrecision<N> i = (-a.R * b.I + a.I * b.R - a.J * b.K + a.K * b.J - a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y) * n;
            MultiPrecision<N> j = (-a.R * b.J + a.I * b.K + a.J * b.R - a.K * b.I - a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X) * n;
            MultiPrecision<N> k = (-a.R * b.K - a.I * b.J + a.J * b.I + a.K * b.R - a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W) * n;
            MultiPrecision<N> w = (-a.R * b.W + a.I * b.X + a.J * b.Y + a.K * b.Z + a.W * b.R - a.X * b.I - a.Y * b.J - a.Z * b.K) * n;
            MultiPrecision<N> x = (-a.R * b.X - a.I * b.W + a.J * b.Z - a.K * b.Y + a.W * b.I + a.X * b.R + a.Y * b.K - a.Z * b.J) * n;
            MultiPrecision<N> y = (-a.R * b.Y - a.I * b.Z - a.J * b.W + a.K * b.X + a.W * b.J - a.X * b.K + a.Y * b.R + a.Z * b.I) * n;
            MultiPrecision<N> z = (-a.R * b.Z + a.I * b.Y - a.J * b.X - a.K * b.W + a.W * b.K + a.X * b.J - a.Y * b.I + a.Z * b.R) * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(MultiPrecision<N> a, Octonion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (MultiPrecision<N>.Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> n = a / b.SquareNorm;

            MultiPrecision<N> r = +b.R * n;
            MultiPrecision<N> i = -b.I * n;
            MultiPrecision<N> j = -b.J * n;
            MultiPrecision<N> k = -b.K * n;
            MultiPrecision<N> w = -b.W * n;
            MultiPrecision<N> x = -b.X * n;
            MultiPrecision<N> y = -b.Y * n;
            MultiPrecision<N> z = -b.Z * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(Octonion<N> a, MultiPrecision<N> b) {
            return a * (1d / b);
        }

        public static Octonion<N> operator /(Octonion<N> a, Complex<N> b) {
            if (Complex<N>.IsFinite(b) && !Complex<N>.IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Ldexp(a, -exp), Complex<N>.Ldexp(b, -exp));
            }

            MultiPrecision<N> n = 1d / b.SquareNorm;

            MultiPrecision<N> r = (+a.R * b.R + a.I * b.I) * n;
            MultiPrecision<N> i = (-a.R * b.I + a.I * b.R) * n;
            MultiPrecision<N> j = (a.J * b.R - a.K * b.I) * n;
            MultiPrecision<N> k = (a.J * b.I + a.K * b.R) * n;
            MultiPrecision<N> w = (a.W * b.R - a.X * b.I) * n;
            MultiPrecision<N> x = (a.W * b.I + a.X * b.R) * n;
            MultiPrecision<N> y = (+a.Y * b.R + a.Z * b.I) * n;
            MultiPrecision<N> z = (-a.Y * b.I + a.Z * b.R) * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(Complex<N> a, Octonion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Complex<N>.Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> n = 1d / b.SquareNorm;

            MultiPrecision<N> r = (+a.R * b.R + a.I * b.I) * n;
            MultiPrecision<N> i = (-a.R * b.I + a.I * b.R) * n;
            MultiPrecision<N> j = (-a.R * b.J + a.I * b.K) * n;
            MultiPrecision<N> k = (-a.R * b.K - a.I * b.J) * n;
            MultiPrecision<N> w = (-a.R * b.W + a.I * b.X) * n;
            MultiPrecision<N> x = (-a.R * b.X - a.I * b.W) * n;
            MultiPrecision<N> y = (-a.R * b.Y - a.I * b.Z) * n;
            MultiPrecision<N> z = (-a.R * b.Z + a.I * b.Y) * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(Octonion<N> a, Quaternion<N> b) {
            if (Quaternion<N>.IsFinite(b) && !Quaternion<N>.IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Ldexp(a, -exp), Quaternion<N>.Ldexp(b, -exp));
            }

            MultiPrecision<N> n = 1d / b.SquareNorm;

            MultiPrecision<N> r = (+a.R * b.R + a.I * b.I + a.J * b.J + a.K * b.K) * n;
            MultiPrecision<N> i = (-a.R * b.I + a.I * b.R - a.J * b.K + a.K * b.J) * n;
            MultiPrecision<N> j = (-a.R * b.J + a.I * b.K + a.J * b.R - a.K * b.I) * n;
            MultiPrecision<N> k = (-a.R * b.K - a.I * b.J + a.J * b.I + a.K * b.R) * n;
            MultiPrecision<N> w = (a.W * b.R - a.X * b.I - a.Y * b.J - a.Z * b.K) * n;
            MultiPrecision<N> x = (a.W * b.I + a.X * b.R + a.Y * b.K - a.Z * b.J) * n;
            MultiPrecision<N> y = (a.W * b.J - a.X * b.K + a.Y * b.R + a.Z * b.I) * n;
            MultiPrecision<N> z = (a.W * b.K + a.X * b.J - a.Y * b.I + a.Z * b.R) * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> operator /(Quaternion<N> a, Octonion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Quaternion<N>.Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> n = 1d / b.SquareNorm;

            MultiPrecision<N> r = (+a.R * b.R + a.I * b.I + a.J * b.J + a.K * b.K) * n;
            MultiPrecision<N> i = (-a.R * b.I + a.I * b.R - a.J * b.K + a.K * b.J) * n;
            MultiPrecision<N> j = (-a.R * b.J + a.I * b.K + a.J * b.R - a.K * b.I) * n;
            MultiPrecision<N> k = (-a.R * b.K - a.I * b.J + a.J * b.I + a.K * b.R) * n;
            MultiPrecision<N> w = (-a.R * b.W + a.I * b.X + a.J * b.Y + a.K * b.Z) * n;
            MultiPrecision<N> x = (-a.R * b.X - a.I * b.W + a.J * b.Z - a.K * b.Y) * n;
            MultiPrecision<N> y = (-a.R * b.Y - a.I * b.Z - a.J * b.W + a.K * b.X) * n;
            MultiPrecision<N> z = (-a.R * b.Z + a.I * b.Y - a.J * b.X - a.K * b.W) * n;

            return new(r, i, j, k, w, x, y, z);
        }

        public static Octonion<N> Inverse(Octonion<N> o) {
            long exp = 0;
            if (IsFinite(o) && !IsZero(o)) {
                exp = o.Exponent;
                o = Ldexp(o, -exp);
            }

            MultiPrecision<N> n = 1d / o.SquareNorm;

            MultiPrecision<N> r = +o.R * n;
            MultiPrecision<N> i = -o.I * n;
            MultiPrecision<N> j = -o.J * n;
            MultiPrecision<N> k = -o.K * n;
            MultiPrecision<N> w = -o.W * n;
            MultiPrecision<N> x = -o.X * n;
            MultiPrecision<N> y = -o.Y * n;
            MultiPrecision<N> z = -o.Z * n;

            return Ldexp(new(r, i, j, k, w, x, y, z), -exp);
        }
    }
}
