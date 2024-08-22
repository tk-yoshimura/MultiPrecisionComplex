using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Sin(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Sin(z.R) * MultiPrecision<N>.Cosh(z.I),
                MultiPrecision<N>.Cos(z.R) * MultiPrecision<N>.Sinh(z.I)
            );
        }

        public static Complex<N> SinPI(Complex<N> z) {
            MultiPrecision<N> i_pi = z.I * MultiPrecision<N>.PI;

            return new Complex<N>(
                MultiPrecision<N>.SinPI(z.R) * MultiPrecision<N>.Cosh(i_pi),
                MultiPrecision<N>.CosPI(z.R) * MultiPrecision<N>.Sinh(i_pi)
            );
        }

        public static Complex<N> Cos(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Cos(z.R) * MultiPrecision<N>.Cosh(z.I),
                -MultiPrecision<N>.Sin(z.R) * MultiPrecision<N>.Sinh(z.I)
            );
        }

        public static Complex<N> CosPI(Complex<N> z) {
            MultiPrecision<N> i_pi = z.I * MultiPrecision<N>.PI;

            return new Complex<N>(
                MultiPrecision<N>.CosPI(z.R) * MultiPrecision<N>.Cosh(i_pi),
                -MultiPrecision<N>.SinPI(z.R) * MultiPrecision<N>.Sinh(i_pi)
            );
        }

        public static Complex<N> Tan(Complex<N> z) {
            MultiPrecision<N> u = MultiPrecision<N>.Exp(-MultiPrecision<N>.Abs(2d * z.I));

            if (u == 1.0) {
                return MultiPrecision<N>.Tan(z.R);
            }

            MultiPrecision<N> n = 1d + u * (2d * MultiPrecision<N>.Cos(2d * z.R) + u);

            if (n.Exponent > -8) {
                MultiPrecision<N> r = 2d * u * MultiPrecision<N>.Sin(2d * z.R) / n;
                MultiPrecision<N> i = (u + 1d) * (u - 1d) / n;
                Complex<N> c = (z.I > 0d) ? (r, -i) : (r, i);

                return c;
            }
            else {
                MultiPrecision<N> x = z.R * MultiPrecision<N>.RcpPI - MultiPrecision<N>.Point5;
                x = (x - MultiPrecision<N>.Round(x)) * MultiPrecision<N>.PI;

                Complex<N> w = (x, z.I);

                Complex<N> c = -Cos(w) / Sin(w);

                return c;
            }
        }

        public static Complex<N> TanPI(Complex<N> z) {
            MultiPrecision<N> u = MultiPrecision<N>.Exp(-MultiPrecision<N>.Abs(2d * z.I * MultiPrecision<N>.PI));

            if (u == 1.0) {
                return MultiPrecision<N>.TanPI(z.R);
            }

            MultiPrecision<N> n = 1d + u * (2d * MultiPrecision<N>.CosPI(2d * z.R) + u);

            if (n.Exponent > -8) {
                MultiPrecision<N> r = 2d * u * MultiPrecision<N>.SinPI(2d * z.R) / n;
                MultiPrecision<N> i = (u + 1d) * (u - 1d) / n;
                Complex<N> c = (z.I > 0d) ? (r, -i) : (r, i);

                return c;
            }
            else {
                MultiPrecision<N> x = z.R - MultiPrecision<N>.Point5;

                Complex<N> w = (x - MultiPrecision<N>.Round(x), z.I);

                Complex<N> c = -CosPI(w) / SinPI(w);

                return c;
            }
        }
    }
}