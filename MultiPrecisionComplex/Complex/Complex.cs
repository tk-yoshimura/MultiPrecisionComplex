using MultiPrecision;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MultiPrecisionComplex {

    [DebuggerDisplay("{Convert<MultiPrecision.Pow2.N4>().ToString(),nq}")]
    public partial class Complex<N> : IFormattable where N : struct, IConstant {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public const char ImaginaryUnit = 'i';

        public readonly MultiPrecision<N> R, I;

        public MultiPrecision<N> Norm => R * R + I * I;

        public MultiPrecision<N> Magnitude => MultiPrecision<N>.Sqrt(Norm);

        public MultiPrecision<N> Phase => MultiPrecision<N>.Atan2(I, R);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Complex<N> Zero { get; } = MultiPrecision<N>.Zero;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Complex<N> NaN { get; } = MultiPrecision<N>.NaN;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Complex<N> One { get; } = (1, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Complex<N> ImaginaryOne { get; } = (0, 1);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Complex<N> Conj => Conjugate(this);

        public static Complex<N> Conjugate(Complex<N> c) => new(c.R, -c.I);

        public static Complex<N> Normal(Complex<N> c) => c / c.Norm;

        public Complex(MultiPrecision<N> r, MultiPrecision<N> i) {
            this.R = r;
            this.I = i;
        }

        public static implicit operator Complex<N>((MultiPrecision<N> r, MultiPrecision<N> i) v) {
            return new(v.r, v.i);
        }

        public static implicit operator Complex<N>(int v) {
            return new(v, MultiPrecision<N>.Zero);
        }

        public static implicit operator Complex<N>(double v) {
            return new(v, MultiPrecision<N>.Zero);
        }

        public static implicit operator Complex<N>(MultiPrecision<N> v) {
            return new(v, MultiPrecision<N>.Zero);
        }

        public static implicit operator Complex<N>(string v) {
            return Parse(v);
        }

        public static implicit operator (MultiPrecision<N> r, MultiPrecision<N> i)(Complex<N> v) {
            return (v.R, v.I);
        }

        public static implicit operator Complex<N>(System.Numerics.Complex c) {
            return new Complex<N>(c.Real, c.Imaginary);
        }

        public static explicit operator System.Numerics.Complex(Complex<N> c) {
            return new System.Numerics.Complex((double)c.R, (double)c.I);
        }

        public void Deconstruct(out MultiPrecision<N> r, out MultiPrecision<N> i) => (r, i) = (R, I);

        public override string ToString() {
            if (IsNaN(this)) {
                return double.NaN.ToString();
            }

            if (R != 0d) {
                if (I == 0d) {
                    return $"{R}";
                }

                return (I > 0d) ? $"{R}+{I}{ImaginaryUnit}" : $"{R}{I}{ImaginaryUnit}";
            }
            else {
                return (I != 0d) ? $"{I}{ImaginaryUnit}" : "0";
            }
        }

        public string ToString([AllowNull] string format, [AllowNull] IFormatProvider formatProvider) {
            if (string.IsNullOrWhiteSpace(format)) {
                return ToString();
            }

            if (IsNaN(this)) {
                return double.NaN.ToString();
            }

            if (R != 0d) {
                if (I == 0d) {
                    return $"{R.ToString(format)}";
                }

                return (I > 0d)
                    ? $"{R.ToString(format)}+{I.ToString(format)}{ImaginaryUnit}"
                    : $"{R.ToString(format)}{I.ToString(format)}{ImaginaryUnit}";
            }
            else {
                return (I != 0d) ? $"{I.ToString(format)}{ImaginaryUnit}" : "0";
            }
        }

        public string ToString(string format) {
            return ToString(format, null);
        }

        public Complex<M> Convert<M>() where M : struct, IConstant {
            return new Complex<M>(R.Convert<M>(), I.Convert<M>());
        }
    }
}
