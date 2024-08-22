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
            MultiPrecision<N> r_sinh = MultiPrecision<N>.Sinh(z.R), r_cosh = MultiPrecision<N>.Cosh(z.R);
            MultiPrecision<N> i_sin = MultiPrecision<N>.Sin(z.I), i_cos = MultiPrecision<N>.Cos(z.I);

            Complex<N> s = new(r_sinh * i_cos, r_cosh * i_sin);
            Complex<N> c = new(r_cosh * i_cos, r_sinh * i_sin);

            return s / c;
        }
    }
}