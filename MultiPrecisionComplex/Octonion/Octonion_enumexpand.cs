using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class OctonionEnumerableExpand {
        public static Octonion<N> Sum<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            Octonion<N> acc = Octonion<N>.Zero, carry = Octonion<N>.Zero;

            foreach (var v in source) {
                Octonion<N> d = v - carry;
                Octonion<N> acc_next = acc + d;

                carry = (acc_next - acc) - d;
                acc = acc_next;
            }

            return acc;
        }

        public static Octonion<N> Average<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            return source.Sum() / source.Count();
        }

        public static IEnumerable<MultiPrecision<N>> R<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.R;
            }
        }

        public static IEnumerable<MultiPrecision<N>> I<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.I;
            }
        }

        public static IEnumerable<MultiPrecision<N>> J<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.J;
            }
        }

        public static IEnumerable<MultiPrecision<N>> K<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.K;
            }
        }

        public static IEnumerable<MultiPrecision<N>> W<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.W;
            }
        }

        public static IEnumerable<MultiPrecision<N>> X<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.X;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Y<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Y;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Z<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Z;
            }
        }

        public static IEnumerable<MultiPrecision<N>> SquareNorm<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.SquareNorm;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Norm<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Norm;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Magnitude<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Magnitude;
            }
        }

        public static IEnumerable<Octonion<N>> Conjugate<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Conj;
            }
        }

        public static IEnumerable<Octonion<N>> Normal<N>(this IEnumerable<Octonion<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Normal;
            }
        }
    }
}