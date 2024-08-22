using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Exp(Complex<N> z) {
            return new Complex<N>(MultiPrecision<N>.Cos(z.I), MultiPrecision<N>.Sin(z.I)) * MultiPrecision<N>.Exp(z.R);
        }
    }
}