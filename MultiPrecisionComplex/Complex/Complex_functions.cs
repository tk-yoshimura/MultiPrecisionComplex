using MultiPrecision;
using System.Numerics;
using System;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> FromPolarCoordinates(MultiPrecision<N> magnitude, MultiPrecision<N> phase) {
            return new Complex<N>(MultiPrecision<N>.Cos(phase) * magnitude, MultiPrecision<N>.Sin(phase) * magnitude);
        }

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

            MultiPrecision<N> r = 2d * u * MultiPrecision<N>.Sin(2d * z.R) / n;
            MultiPrecision<N> i = (u + 1d) * (u - 1d) / n;
            Complex<N> c = (z.I > 0d) ? (r, -i) : (r, i);

            return c;
        }

        public static Complex<N> TanPI(Complex<N> z) {
            MultiPrecision<N> u = MultiPrecision<N>.Exp(-MultiPrecision<N>.Abs(2d * z.I * MultiPrecision<N>.PI));
            
            if (u == 1.0) {
                return MultiPrecision<N>.TanPI(z.R);
            }

            MultiPrecision<N> n = 1d + u * (2d * MultiPrecision<N>.CosPI(2d * z.R) + u);

            MultiPrecision<N> r = 2d * u * MultiPrecision<N>.SinPI(2d * z.R) / n;
            MultiPrecision<N> i = (u + 1d) * (u - 1d) / n;
            Complex<N> c = (z.I > 0d) ? (r, -i) : (r, i);

            return c;
        }

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

        public static Complex<N> Asin(Complex<N> z) {
            return -ImaginaryOne * Log(ImaginaryOne * z + Sqrt(1d - z * z));
        }

        public static Complex<N> Acos(Complex<N> z) {
            return -ImaginaryOne * Log(z + ImaginaryOne * Sqrt(1d - z * z));
        }

        public static Complex<N> Atan(Complex<N> z) {
            return ImaginaryOne / 2 * (Log(One - ImaginaryOne * z) - Log(One + ImaginaryOne * z));
        }

        public static Complex<N> Log(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log(z.Magnitude),
                z.Phase
            );
        }

        public static Complex<N> Log2(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log2(z.Magnitude),
                z.Phase * MultiPrecision<N>.LbE
            );
        }

        public static Complex<N> Log10(Complex<N> z) {
            return new Complex<N>(
                MultiPrecision<N>.Log10(z.Magnitude),
                z.Phase / MultiPrecision<N>.Log(10)
            );
        }

        public static Complex<N> Log(Complex<N> z, MultiPrecision<N> b) {
            return Log(z) / MultiPrecision<N>.Log(b);
        }

        public static Complex<N> Exp(Complex<N> z) {
            return new Complex<N>(MultiPrecision<N>.Cos(z.I), MultiPrecision<N>.Sin(z.I)) * MultiPrecision<N>.Exp(z.R);
        }

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

        public static Complex<N> Sqrt(Complex<N> z) {
            return FromPolarCoordinates(MultiPrecision<N>.Sqrt(z.Magnitude), z.Phase / 2);
        }

        public static Complex<N> Cbrt(Complex<N> z) {
            return FromPolarCoordinates(MultiPrecision<N>.Cbrt(z.Magnitude), z.Phase / 3);
        }

        public static Complex<N> RootN(Complex<N> z, int n) {
            return FromPolarCoordinates(MultiPrecision<N>.Pow(z.Magnitude, MultiPrecision<N>.Div(1, n)), z.Phase / n);
        }
    }
}