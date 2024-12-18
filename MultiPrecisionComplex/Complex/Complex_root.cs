﻿using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Sqrt(Complex<N> z) {
            return FromPolarCoordinates(MultiPrecision<N>.Sqrt(z.Norm), z.Phase / 2);
        }

        public static Complex<N> Cbrt(Complex<N> z) {
            return FromPolarCoordinates(MultiPrecision<N>.Cbrt(z.Norm), z.Phase / 3);
        }

        public static Complex<N> RootN(Complex<N> z, int n) {
            return FromPolarCoordinates(MultiPrecision<N>.Pow(z.Norm, MultiPrecision<N>.Div(1, n)), z.Phase / n);
        }
    }
}