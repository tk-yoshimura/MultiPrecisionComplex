using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Pow(Complex<N> z, Complex<N> p) {
            if (IsZero(p)) {
                return 1;
            }
            if (IsZero(z)) {
                return Zero;
            }

            MultiPrecision<N> rho = z.Magnitude, theta = z.Phase;
            MultiPrecision<N> phi = p.R * z.Phase + p.I * MultiPrecision<N>.Log(rho);
            MultiPrecision<N> s = MultiPrecision<N>.Pow(rho, p.R) * MultiPrecision<N>.Pow(MultiPrecision<N>.E, -p.I * theta);

            return new Complex<N>(MultiPrecision<N>.Cos(phi) * s, MultiPrecision<N>.Sin(phi) * s);
        }

        public static Complex<N> Pow(Complex<N> z, MultiPrecision<N> p) {
            return FromPolarCoordinates(MultiPrecision<N>.Pow(z.Magnitude, p), z.Phase * p);
        }

        public static Complex<N> Pow(Complex<N> z, long n) {
            return FromPolarCoordinates(MultiPrecision<N>.Pow(z.Magnitude, n), z.Phase * n);
        }

        public static Complex<N> Pow2(Complex<N> z) {
            MultiPrecision<N> phi = z.I * MultiPrecision<N>.Ln2;
            MultiPrecision<N> s = MultiPrecision<N>.Pow2(z.R);

            return new Complex<N>(MultiPrecision<N>.Cos(phi) * s, MultiPrecision<N>.Sin(phi) * s);
        }

        public static Complex<N> Pow(MultiPrecision<N> x, Complex<N> z) {
            MultiPrecision<N> phi = z.I * MultiPrecision<N>.Log(x);
            MultiPrecision<N> s = MultiPrecision<N>.Pow(x, z.R);

            return new Complex<N>(MultiPrecision<N>.Cos(phi) * s, MultiPrecision<N>.Sin(phi) * s);
        }
    }
}