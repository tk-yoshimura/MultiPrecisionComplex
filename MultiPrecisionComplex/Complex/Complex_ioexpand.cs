using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class ComplexIOExpand {

        public static void Write<N>(this BinaryWriter writer, Complex<N> v) where N : struct, IConstant {
            MultiPrecisionIOExpand.Write(writer, v.R);
            MultiPrecisionIOExpand.Write(writer, v.I);
        }

        public static Complex<N> ReadComplex<N>(this BinaryReader reader) where N : struct, IConstant {
            MultiPrecision<N> r = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> i = reader.ReadMultiPrecision<N>();

            return (r, i);
        }
    }
}
