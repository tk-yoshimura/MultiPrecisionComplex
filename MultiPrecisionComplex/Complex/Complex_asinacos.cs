namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Asin(Complex<N> z) {
            return MulMinusI(Log(MulI(z) + Sqrt(1d - z * z)));
        }

        public static Complex<N> Acos(Complex<N> z) {
            return MulMinusI(Log(z + MulI(Sqrt(1d - z * z))));
        }

        public static Complex<N> Atan(Complex<N> z) {
            return ImaginaryOne / 2 * (Log(One - MulI(z)) - Log(One + MulI(z)));
        }
    }
}