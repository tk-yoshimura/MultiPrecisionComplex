using MultiPrecision;
using System.Numerics;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> :
        IAdditionOperators<Quaternion<N>, Quaternion<N>, Quaternion<N>>,
        ISubtractionOperators<Quaternion<N>, Quaternion<N>, Quaternion<N>>,
        IMultiplyOperators<Quaternion<N>, Quaternion<N>, Quaternion<N>>,
        IDivisionOperators<Quaternion<N>, Quaternion<N>, Quaternion<N>>,

        IUnaryPlusOperators<Quaternion<N>, Quaternion<N>>,
        IUnaryNegationOperators<Quaternion<N>, Quaternion<N>>,

        IEqualityOperators<Quaternion<N>, Quaternion<N>, bool> {

        public static Quaternion<N> operator +(Quaternion<N> q) {
            return q;
        }

        public static Quaternion<N> operator -(Quaternion<N> q) {
            return new(-q.R, -q.I, -q.J, -q.K);
        }

        public static Quaternion<N> operator +(Quaternion<N> a, Quaternion<N> b) {
            return new(a.R + b.R, a.I + b.I, a.J + b.J, a.K + b.K);
        }

        public static Quaternion<N> operator +(Quaternion<N> a, MultiPrecision<N> b) {
            return new(a.R + b, a.I, a.J, a.K);
        }

        public static Quaternion<N> operator +(MultiPrecision<N> a, Quaternion<N> b) {
            return new(a + b.R, b.I, b.J, b.K);
        }

        public static Quaternion<N> operator -(Quaternion<N> a, Quaternion<N> b) {
            return new(a.R - b.R, a.I - b.I, a.J - b.J, a.K - b.K);
        }

        public static Quaternion<N> operator -(Quaternion<N> a, MultiPrecision<N> b) {
            return new(a.R - b, a.I, a.J, a.K);
        }

        public static Quaternion<N> operator -(MultiPrecision<N> a, Quaternion<N> b) {
            return new(a - b.R, -b.I, -b.J, -b.K);
        }

        public static Quaternion<N> operator *(Quaternion<N> a, Quaternion<N> b) {
            return new(
                a.R * b.R - a.I * b.I - a.J * b.J - a.K * b.K,
                a.I * b.R + a.R * b.I - a.K * b.J + a.J * b.K,
                a.J * b.R + a.K * b.I + a.R * b.J - a.I * b.K,
                a.K * b.R - a.J * b.I + a.I * b.J + a.R * b.K
            );
        }

        public static Quaternion<N> operator *(Quaternion<N> a, MultiPrecision<N> b) {
            return new(a.R * b, a.I * b, a.J * b, a.K * b);
        }

        public static Quaternion<N> operator *(MultiPrecision<N> a, Quaternion<N> b) {
            return new(a * b.R, a * b.I, a * b.J, a * b.K);
        }

        public static Quaternion<N> operator *(Quaternion<N> a, Complex<N> b) {
            return new(
                a.R * b.R - a.I * b.I,
                a.I * b.R + a.R * b.I,
                a.J * b.R + a.K * b.I,
                a.K * b.R - a.J * b.I
            );
        }

        public static Quaternion<N> operator *(Complex<N> a, Quaternion<N> b) {
            return new(
                a.R * b.R - a.I * b.I,
                a.I * b.R + a.R * b.I,
                a.R * b.J - a.I * b.K,
                a.I * b.J + a.R * b.K
            );
        }

        public static Quaternion<N> operator /(Quaternion<N> a, Quaternion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> s = 1d / b.SquareNorm;

            return new(
                (a.R * b.R + a.I * b.I + a.J * b.J + a.K * b.K) * s,
                (a.I * b.R - a.R * b.I + a.K * b.J - a.J * b.K) * s,
                (a.J * b.R - a.K * b.I - a.R * b.J + a.I * b.K) * s,
                (a.K * b.R + a.J * b.I - a.I * b.J - a.R * b.K) * s
            );
        }

        public static Quaternion<N> operator /(MultiPrecision<N> a, Quaternion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (MultiPrecision<N>.Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> s = a / b.SquareNorm;

            return new(b.R * s, -b.I * s, -b.J * s, -b.K * s);
        }

        public static Quaternion<N> operator /(Quaternion<N> a, MultiPrecision<N> b) {
            return a * (1d / b);
        }

        public static Quaternion<N> operator /(Quaternion<N> a, Complex<N> b) {
            if (Complex<N>.IsFinite(b) && !Complex<N>.IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Ldexp(a, -exp), Complex<N>.Ldexp(b, -exp));
            }

            MultiPrecision<N> s = 1d / b.SquareNorm;

            return new(
                (a.R * b.R + a.I * b.I) * s,
                (a.I * b.R - a.R * b.I) * s,
                (a.J * b.R - a.K * b.I) * s,
                (a.K * b.R + a.J * b.I) * s
            );
        }

        public static Quaternion<N> operator /(Complex<N> a, Quaternion<N> b) {
            if (IsFinite(b) && !IsZero(b)) {
                long exp = b.Exponent;
                (a, b) = (Complex<N>.Ldexp(a, -exp), Ldexp(b, -exp));
            }

            MultiPrecision<N> s = 1d / b.SquareNorm;

            return new(
                (a.R * b.R + a.I * b.I) * s,
                (a.I * b.R - a.R * b.I) * s,
                (-a.R * b.J + a.I * b.K) * s,
                (-a.I * b.J - a.R * b.K) * s
            );
        }

        public static Quaternion<N> Inverse(Quaternion<N> q) {
            long exp = 0;
            if (IsFinite(q) && !IsZero(q)) {
                exp = q.Exponent;
                q = Ldexp(q, -exp);
            }

            MultiPrecision<N> s = 1d / q.SquareNorm;

            return Ldexp(new(q.R * s, -q.I * s, -q.J * s, -q.K * s), -exp);
        }
    }
}
