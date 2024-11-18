using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Log(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log(z.Norm),
                z.Phase
            );
        }

        public static Complex<N> Log2(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log2(z.Norm),
                z.Phase * MultiPrecision<N>.LbE
            );
        }

        public static Complex<N> Log10(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log10(z.Norm),
                z.Phase / MultiPrecision<N>.Log(10)
            );
        }

        public static Complex<N> Log(Complex<N> z, MultiPrecision<N> b) {
            return Log(z) / MultiPrecision<N>.Log(b);
        }
    }
}