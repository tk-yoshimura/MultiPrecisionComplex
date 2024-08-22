namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> Sinh(Quaternion<N> q) {
            Quaternion<N> q_pexp = Exp(q), q_mexp = Exp(-q);

            return (q_pexp - q_mexp) / 2;
        }

        public static Quaternion<N> Cosh(Quaternion<N> q) {
            Quaternion<N> q_pexp = Exp(q), q_mexp = Exp(-q);

            return (q_pexp + q_mexp) / 2;
        }

        public static Quaternion<N> Tanh(Quaternion<N> q) {
            Quaternion<N> q_pexp = Exp(q), q_mexp = Exp(-q);

            return (q_pexp - q_mexp) / (q_pexp + q_mexp);
        }
    }
}
