using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class QuaternionEnumerableExpand {
        public static Quaternion<N> Sum<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            Quaternion<N> acc = Quaternion<N>.Zero, carry = Quaternion<N>.Zero;

            foreach (var v in source) {
                Quaternion<N> d = v - carry;
                Quaternion<N> acc_next = acc + d;

                carry = (acc_next - acc) - d;
                acc = acc_next;
            }

            return acc;
        }

        public static Quaternion<N> Average<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            return source.Sum() / source.Count();
        }

        public static IEnumerable<MultiPrecision<N>> R<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.R;
            }
        }

        public static IEnumerable<MultiPrecision<N>> I<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.I;
            }
        }

        public static IEnumerable<MultiPrecision<N>> J<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.J;
            }
        }

        public static IEnumerable<MultiPrecision<N>> K<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.K;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Norm<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Norm;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Magnitude<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Magnitude;
            }
        }

        public static IEnumerable<Quaternion<N>> Conjugate<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Conj;
            }
        }

        public static IEnumerable<Quaternion<N>> Normal<N>(this IEnumerable<Quaternion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return Quaternion<N>.Normal(v);
            }
        }
    }
}