using MultiPrecision;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MultiPrecisionComplex {

    [DebuggerDisplay("{Convert<MultiPrecision.Pow2.N4>().ToString(),nq}")]
    public partial class Quaternion<N> : IFormattable where N : struct, IConstant {
        public readonly MultiPrecision<N> R, I, J, K;

        public MultiPrecision<N> Norm => R * R + I * I + J * J + K * K;

        public MultiPrecision<N> Magnitude => MultiPrecision<N>.Sqrt(Norm);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public (MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) Vector => (I, J, K);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> Zero { get; } = MultiPrecision<N>.Zero;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> NaN { get; } = MultiPrecision<N>.NaN;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> One { get; } = (1, 0, 0, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> IOne { get; } = (0, 1, 0, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> JOne { get; } = (0, 0, 1, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Quaternion<N> KOne { get; } = (0, 0, 0, 1);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Quaternion<N> Conj => Conjugate(this);

        public static Quaternion<N> Conjugate(Quaternion<N> q) => new(q.R, -q.I, -q.J, -q.K);

        public static Quaternion<N> Normal(Quaternion<N> q) => q / q.Norm;

        public static Quaternion<N> VectorPart(Quaternion<N> q) {
            return new Quaternion<N>(MultiPrecision<N>.Zero, q.I, q.J, q.K);
        }

        public static Quaternion<N> RealPart(Quaternion<N> q) {
            return new Quaternion<N>(q.R, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public Quaternion(MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k) {
            this.R = r;
            this.I = i;
            this.J = j;
            this.K = k;
        }

        public static implicit operator Quaternion<N>((MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k) v) {
            return new(v.r, v.i, v.j, v.k);
        }

        public static implicit operator Quaternion<N>(int v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Quaternion<N>(double v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Quaternion<N>(MultiPrecision<N> v) {
            return new(v, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Quaternion<N>(Complex<N> z) {
            return new(z.R, z.I, MultiPrecision<N>.Zero, MultiPrecision<N>.Zero);
        }

        public static implicit operator Quaternion<N>((MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) v) {
            return new(MultiPrecision<N>.Zero, v.x, v.y, v.z);
        }

        public static implicit operator (MultiPrecision<N> r, MultiPrecision<N> i, MultiPrecision<N> j, MultiPrecision<N> k)(Quaternion<N> v) {
            return (v.R, v.I, v.J, v.K);
        }

        public static implicit operator Quaternion<N>(System.Numerics.Quaternion q) {
            return new Quaternion<N>(q.W, q.X, q.Y, q.Z);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public long Exponent => long.Max(long.Max(R.Exponent, I.Exponent), long.Max(J.Exponent, K.Exponent));

        public static Quaternion<N> Ldexp(Quaternion<N> q, long n) {
            return (
                MultiPrecision<N>.Ldexp(q.R, n), MultiPrecision<N>.Ldexp(q.I, n),
                MultiPrecision<N>.Ldexp(q.J, n), MultiPrecision<N>.Ldexp(q.K, n)
            );
        }

        public static implicit operator Quaternion<N>(string v) {
            return Parse(v);
        }

        public static explicit operator System.Numerics.Quaternion(Quaternion<N> q) {
            return new System.Numerics.Quaternion((float)q.I, (float)q.J, (float)q.K, (float)q.R);
        }

        public void Deconstruct(out MultiPrecision<N> r, out MultiPrecision<N> i, out MultiPrecision<N> j, out MultiPrecision<N> k)
            => (r, i, j, k) = (R, I, J, K);

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

            if (str.Length > 0 && str[0] == '+') {
                str.Remove(0, 1);
            }

            return (str.Length > 0) ? str.ToString() : "0";
        }

        public string ToString(string format) {
            return ToString(format, null);
        }

        public Quaternion<M> Convert<M>() where M : struct, IConstant {
            return new Quaternion<M>(R.Convert<M>(), I.Convert<M>(), J.Convert<M>(), K.Convert<M>());
        }
    }
}
