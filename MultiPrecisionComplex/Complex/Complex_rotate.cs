using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Complex<N> {

        public static Complex<N> FromPhase(MultiPrecision<N> phase)
            => (MultiPrecision<N>.Cos(phase), MultiPrecision<N>.Sin(phase));

        public static Complex<N> FromPhasePi(MultiPrecision<N> phase)
            => (MultiPrecision<N>.CosPi(phase), MultiPrecision<N>.SinPi(phase));

        public static Complex<N> FromPolar(MultiPrecision<N> magnitude, MultiPrecision<N> phase)
            => (magnitude * MultiPrecision<N>.Cos(phase), magnitude * MultiPrecision<N>.Sin(phase));

        public static Complex<N> FromPolarPi(MultiPrecision<N> magnitude, MultiPrecision<N> phase)
            => (magnitude * MultiPrecision<N>.CosPi(phase), magnitude * MultiPrecision<N>.SinPi(phase));
    }
}
