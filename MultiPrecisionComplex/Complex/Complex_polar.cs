using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> FromPolarCoordinates(MultiPrecision<N> magnitude, MultiPrecision<N> phase) {
            return new Complex<N>(MultiPrecision<N>.Cos(phase) * magnitude, MultiPrecision<N>.Sin(phase) * magnitude);
        }
    }
}