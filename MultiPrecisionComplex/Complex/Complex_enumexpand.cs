using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class ComplexEnumerableExpand {
        public static Complex<N> Sum<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            Complex<N> acc = Complex<N>.Zero, carry = Complex<N>.Zero;

            foreach (var v in source) {
                Complex<N> d = v - carry;
                Complex<N> acc_next = acc + d;

                carry = (acc_next - acc) - d;
                acc = acc_next;
            }

            return acc;
        }

        public static Complex<N> Average<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            return source.Sum() / source.Count();
        }

        public static IEnumerable<MultiPrecision<N>> R<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.R;
            }
        }

        public static IEnumerable<MultiPrecision<N>> I<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.I;
            }
        }

        public static IEnumerable<MultiPrecision<N>> SquareNorm<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.SquareNorm;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Norm<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Norm;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Magnitude<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Magnitude;
            }
        }

        public static IEnumerable<MultiPrecision<N>> Phase<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Phase;
            }
        }

        public static IEnumerable<Complex<N>> Conjugate<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Conj;
            }
        }

        public static IEnumerable<Complex<N>> Normal<N>(this IEnumerable<Complex<N>> source) where N : struct, IConstant {
            foreach (var v in source) {
                yield return v.Normal;
            }
        }
    }
}
