using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Sinh(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Sinh(z.R) * MultiPrecision<N>.Cos(z.I),
                MultiPrecision<N>.Cosh(z.R) * MultiPrecision<N>.Sin(z.I)
            );
        }

        public static Complex<N> Cosh(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Cosh(z.R) * MultiPrecision<N>.Cos(z.I),
                MultiPrecision<N>.Sinh(z.R) * MultiPrecision<N>.Sin(z.I)
            );
        }

        public static Complex<N> Tanh(Complex<N> z) {
            return -ImaginaryOne * Tan(ImaginaryOne * z);
        }
    }
}