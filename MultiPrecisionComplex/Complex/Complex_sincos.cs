using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Sin(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Sin(z.R) * MultiPrecision<N>.Cosh(z.I),
                MultiPrecision<N>.Cos(z.R) * MultiPrecision<N>.Sinh(z.I)
            );
        }

        public static Complex<N> SinPi(Complex<N> z) {
            MultiPrecision<N> i_pi = z.I * MultiPrecision<N>.Pi;

            return new Complex<N>(
                MultiPrecision<N>.SinPi(z.R) * MultiPrecision<N>.Cosh(i_pi),
                MultiPrecision<N>.CosPi(z.R) * MultiPrecision<N>.Sinh(i_pi)
            );
        }

        public static Complex<N> Cos(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Cos(z.R) * MultiPrecision<N>.Cosh(z.I),
                -MultiPrecision<N>.Sin(z.R) * MultiPrecision<N>.Sinh(z.I)
            );
        }

        public static Complex<N> CosPi(Complex<N> z) {
            MultiPrecision<N> i_pi = z.I * MultiPrecision<N>.Pi;

            return new Complex<N>(
                MultiPrecision<N>.CosPi(z.R) * MultiPrecision<N>.Cosh(i_pi),
                -MultiPrecision<N>.SinPi(z.R) * MultiPrecision<N>.Sinh(i_pi)
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
                MultiPrecision<N> x = z.R * MultiPrecision<N>.RcpPi - MultiPrecision<N>.Point5;
                x = (x - MultiPrecision<N>.Round(x)) * MultiPrecision<N>.Pi;

                Complex<N> w = (x, z.I);

                Complex<N> c = -Cos(w) / Sin(w);

                return c;
            }
        }

        public static Complex<N> TanPi(Complex<N> z) {
            MultiPrecision<N> u = MultiPrecision<N>.Exp(-MultiPrecision<N>.Abs(2d * z.I * MultiPrecision<N>.Pi));

            if (u == 1.0) {
                return MultiPrecision<N>.TanPi(z.R);
            }

            MultiPrecision<N> n = 1d + u * (2d * MultiPrecision<N>.CosPi(2d * z.R) + u);

            if (n.Exponent > -8) {
                MultiPrecision<N> r = 2d * u * MultiPrecision<N>.SinPi(2d * z.R) / n;
                MultiPrecision<N> i = (u + 1d) * (u - 1d) / n;
                Complex<N> c = (z.I > 0d) ? (r, -i) : (r, i);

                return c;
            }
            else {
                MultiPrecision<N> x = z.R - MultiPrecision<N>.Point5;

                Complex<N> w = (x - MultiPrecision<N>.Round(x), z.I);

                Complex<N> c = -CosPi(w) / SinPi(w);

                return c;
            }
        }
    }
}