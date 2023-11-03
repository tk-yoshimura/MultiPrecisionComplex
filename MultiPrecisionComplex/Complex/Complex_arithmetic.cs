using MultiPrecision;
using System.Numerics;

namespace MultiPrecisionComplex {

    public partial class Complex<N> :
        IAdditionOperators<Complex<N>, Complex<N>, Complex<N>>,
        ISubtractionOperators<Complex<N>, Complex<N>, Complex<N>>,
        IMultiplyOperators<Complex<N>, Complex<N>, Complex<N>>,
        IDivisionOperators<Complex<N>, Complex<N>, Complex<N>>,

        IUnaryPlusOperators<Complex<N>, Complex<N>>,
        IUnaryNegationOperators<Complex<N>, Complex<N>>,

        IEqualityOperators<Complex<N>, Complex<N>, bool> {

        public static Complex<N> operator +(Complex<N> c) {
            return c;
        }

        public static Complex<N> operator -(Complex<N> c) {
            return new(-c.R, -c.I);
        }

        public static Complex<N> operator +(Complex<N> a, Complex<N> b) {
            return new(a.R + b.R, a.I + b.I);
        }

        public static Complex<N> operator +(Complex<N> a, MultiPrecision<N> b) {
            return new(a.R + b, a.I);
        }

        public static Complex<N> operator +(MultiPrecision<N> a, Complex<N> b) {
            return new(a + b.R, b.I);
        }

        public static Complex<N> operator -(Complex<N> a, Complex<N> b) {
            return new(a.R - b.R, a.I - b.I);
        }

        public static Complex<N> operator -(Complex<N> a, MultiPrecision<N> b) {
            return new(a.R - b, a.I);
        }

        public static Complex<N> operator -(MultiPrecision<N> a, Complex<N> b) {
            return new(a - b.R, -b.I);
        }

        public static Complex<N> operator *(Complex<N> a, Complex<N> b) {
            return new(a.R * b.R - a.I * b.I, a.I * b.R + a.R * b.I);
        }

        public static Complex<N> operator *(Complex<N> a, MultiPrecision<N> b) {
            return new(a.R * b, a.I * b);
        }

        public static Complex<N> operator *(MultiPrecision<N> a, Complex<N> b) {
            return new(a * b.R, a * b.I);
        }

        public static Complex<N> operator /(Complex<N> a, Complex<N> b) {
            MultiPrecision<N> s = 1d / b.Norm;

            return new((a.R * b.R + a.I * b.I) * s, (a.I * b.R - a.R * b.I) * s);
        }

        public static Complex<N> operator /(MultiPrecision<N> a, Complex<N> b) {
            MultiPrecision<N> s = a / b.Norm;

            return new(b.R * s, -b.I * s);
        }

        public static Complex<N> operator /(Complex<N> a, MultiPrecision<N> b) {
            return a * (1d / b);
        }

        public static Complex<N> Inverse(Complex<N> z) {
            MultiPrecision<N> s = 1d / z.Norm;

            return new(z.R * s, -z.I * s);
        }
    }
}
