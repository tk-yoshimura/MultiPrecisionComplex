using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class OctonionIOExpand {

        public static void Write<N>(this BinaryWriter writer, Octonion<N> v) where N : struct, IConstant {
            MultiPrecisionIOExpand.Write(writer, v.R);
            MultiPrecisionIOExpand.Write(writer, v.I);
            MultiPrecisionIOExpand.Write(writer, v.J);
            MultiPrecisionIOExpand.Write(writer, v.K);
            MultiPrecisionIOExpand.Write(writer, v.W);
            MultiPrecisionIOExpand.Write(writer, v.X);
            MultiPrecisionIOExpand.Write(writer, v.Y);
            MultiPrecisionIOExpand.Write(writer, v.Z);
        }

        public static Octonion<N> ReadOctonion<N>(this BinaryReader reader) where N : struct, IConstant {
            MultiPrecision<N> r = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> i = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> j = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> k = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> w = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> x = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> y = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> z = reader.ReadMultiPrecision<N>();

            return (r, i, j, k, w, x, y, z);
        }
    }
}
