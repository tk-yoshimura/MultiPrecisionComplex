using MultiPrecision;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MultiPrecisionComplex {

    [DebuggerDisplay("{Convert<MultiPrecision.Pow2.N4>().ToString(),nq}")]
    public partial class Octonion<N> : IFormattable where N : struct, IConstant {
        public readonly MultiPrecision<N> R, I, J, K, W, X, Y, Z;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MultiPrecision<N> SquareNorm => R * R + I * I + J * J + K * K + W * W + X * X + Y * Y + Z * Z;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MultiPrecision<N> Norm {
            get {
                if (MultiPrecision<N>.IsInfinity(R) || MultiPrecision<N>.IsInfinity(I) || MultiPrecision<N>.IsInfinity(J) || MultiPrecision<N>.IsInfinity(K) ||
                    MultiPrecision<N>.IsInfinity(W) || MultiPrecision<N>.IsInfinity(X) || MultiPrecision<N>.IsInfinity(Y) || MultiPrecision<N>.IsInfinity(Z)) {

                    return MultiPrecision<N>.PositiveInfinity;
                }

                long exp = Exponent;

                if (exp <= int.MinValue) {
                    return 0d;
                }

                Octonion<N> o = Ldexp(this, -exp);

                MultiPrecision<N> m = MultiPrecision<N>.Ldexp(MultiPrecision<N>.Sqrt(
                    o.R * o.R + o.I * o.I + o.J * o.J + o.K * o.K +
                    o.W * o.W + o.X * o.X + o.Y * o.Y + o.Z * o.Z), exp
                );

                return m;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MultiPrecision<N> Magnitude => Norm;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Octonion<N> Zero { get; } = MultiPrecision<N>.Zero;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Octonion<N> NaN { get; } = MultiPrecision<N>.NaN;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Octonion<N> One { get; } = (1, 0, 0, 0, 0, 0, 0, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Octonion<N> Conj => Conjugate(this);

        public static Octonion<N> Conjugate(Octonion<N> q) => new(q.R, -q.I, -q.J, -q.K, -q.W, -q.X, -q.Y, -q.Z);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Octonion<N> Normal => this / Norm;

        public Octonion(MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k, MultiPrecision<N> w, MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) {
            this.R = r;
            this.I = i;
            this.J = j;
            this.K = k;
            this.W = w;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static implicit operator Octonion<N>((MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k, MultiPrecision<N> w, MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) v) {
            return new(v.r, v.i, v.j, v.k, v.w, v.x, v.y, v.z);
        }

        public static implicit operator Octonion<N>(int v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Octonion<N>(double v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Octonion<N>(MultiPrecision<N> v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Octonion<N>(Complex<N> z) {
            return new(z.R, z.I, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Octonion<N>(Quaternion<N> q) {
            return new(q.R, q.I, q.J, q.K, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator (MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k, MultiPrecision<N> w, MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z)(Octonion<N> v) {
            return (v.R, v.I, v.J, v.K, v.W, v.X, v.Y, v.X);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public long Exponent => long.Max(
            long.Max(
                long.Max(R.Exponent, I.Exponent),
                long.Max(J.Exponent, K.Exponent)
            ),
            long.Max(
                long.Max(W.Exponent, X.Exponent),
                long.Max(Y.Exponent, Z.Exponent)
            )
        );

        public static Octonion<N> Ldexp(Octonion<N> o, long n) {
            return (
                MultiPrecision<N>.Ldexp(o.R, n), MultiPrecision<N>.Ldexp(o.I, n), MultiPrecision<N>.Ldexp(o.J, n), MultiPrecision<N>.Ldexp(o.K, n),
                MultiPrecision<N>.Ldexp(o.W, n), MultiPrecision<N>.Ldexp(o.X, n), MultiPrecision<N>.Ldexp(o.Y, n), MultiPrecision<N>.Ldexp(o.Z, n)
            );
        }

        public static implicit operator Octonion<N>(string v) {
            return Parse(v);
        }

        public void Deconstruct(out MultiPrecision<N> r, out MultiPrecision<N> i, out MultiPrecision<N> j, out MultiPrecision<N> k, out MultiPrecision<N> w, out MultiPrecision<N> x, out MultiPrecision<N> y, out MultiPrecision<N> z)
            => (r, i, j, k, w, x, y, z) = (R, I, J, K, W, X, Y, Z);

        public override string ToString() {
            if (IsNaN(this)) {
                return double.NaN.ToString();
            }

            StringBuilder str = new();

            if (R != 0d) {
                str.Append($"{R}");
            }
            if (I != 0d) {
                str.Append(I > 0d ? $"+{I}i" : $"{I}i");
            }
            if (J != 0d) {
                str.Append(J > 0d ? $"+{J}j" : $"{J}j");
            }
            if (K != 0d) {
                str.Append(K > 0d ? $"+{K}k" : $"{K}k");
            }
            if (W != 0d) {
                str.Append(W > 0d ? $"+{W}w" : $"{W}w");
            }
            if (X != 0d) {
                str.Append(X > 0d ? $"+{X}x" : $"{X}x");
            }
            if (Y != 0d) {
                str.Append(Y > 0d ? $"+{Y}y" : $"{Y}y");
            }
            if (Z != 0d) {
                str.Append(Z > 0d ? $"+{Z}z" : $"{Z}z");
            }

            if (str.Length > 0 && str[0] == '+') {
                str.Remove(0, 1);
            }

            return (str.Length > 0) ? str.ToString() : "0";
        }

        public string ToString([AllowNull] string format, [AllowNull] IFormatProvider formatProvider) {
            if (string.IsNullOrWhiteSpace(format)) {
                return ToString();
            }

            if (IsNaN(this)) {
                return double.NaN.ToString();
            }

            StringBuilder str = new();

            if (R != 0d) {
                str.Append($"{R.ToString(format)}");
            }
            if (I != 0d) {
                str.Append(I > 0d ? $"+{I.ToString(format)}i" : $"{I.ToString(format)}i");
            }
            if (J != 0d) {
                str.Append(J > 0d ? $"+{J.ToString(format)}j" : $"{J.ToString(format)}j");
            }
            if (K != 0d) {
                str.Append(K > 0d ? $"+{K.ToString(format)}k" : $"{K.ToString(format)}k");
            }
            if (W != 0d) {
                str.Append(W > 0d ? $"+{W.ToString(format)}w" : $"{W.ToString(format)}w");
            }
            if (X != 0d) {
                str.Append(X > 0d ? $"+{X.ToString(format)}x" : $"{X.ToString(format)}x");
            }
            if (Y != 0d) {
                str.Append(Y > 0d ? $"+{Y.ToString(format)}y" : $"{Y.ToString(format)}y");
            }
            if (Z != 0d) {
                str.Append(Z > 0d ? $"+{Z.ToString(format)}z" : $"{Z.ToString(format)}z");
            }

            if (str.Length > 0 && str[0] == '+') {
                str.Remove(0, 1);
            }

            return (str.Length > 0) ? str.ToString() : "0";
        }

        public string ToString(string format) {
            return ToString(format, null);
        }

        public Octonion<M> Convert<M>() where M : struct, IConstant {
            return new Octonion<M>(
                R.Convert<M>(), I.Convert<M>(), J.Convert<M>(), K.Convert<M>(),
                W.Convert<M>(), X.Convert<M>(), Y.Convert<M>(), Z.Convert<M>()
            );
        }
    }
}
