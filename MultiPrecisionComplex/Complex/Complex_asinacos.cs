namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> Asin(Complex<N> z) {
            return -ImaginaryOne * Log(ImaginaryOne * z + Sqrt(1d - z * z));
        }

        public static Complex<N> Acos(Complex<N> z) {
            return -ImaginaryOne * Log(z + ImaginaryOne * Sqrt(1d - z * z));
        }

        public static Complex<N> Atan(Complex<N> z) {
            return ImaginaryOne / 2 * (Log(One - ImaginaryOne * z) - Log(One + ImaginaryOne * z));
        }
    }
}