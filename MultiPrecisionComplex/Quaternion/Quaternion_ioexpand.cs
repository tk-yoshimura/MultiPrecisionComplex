using MultiPrecision;

namespace MultiPrecisionComplex {

    public static class QuaternionIOExpand {

        public static void Write<N>(this BinaryWriter writer, Quaternion<N> v) where N : struct, IConstant {
            MultiPrecisionIOExpand.Write(writer, v.R);
            MultiPrecisionIOExpand.Write(writer, v.I);
            MultiPrecisionIOExpand.Write(writer, v.J);
            MultiPrecisionIOExpand.Write(writer, v.K);
        }

        public static Quaternion<N> ReadQuaternion<N>(this BinaryReader reader) where N : struct, IConstant {
            MultiPrecision<N> r = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> i = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> j = reader.ReadMultiPrecision<N>();
            MultiPrecision<N> k = reader.ReadMultiPrecision<N>();

            return (r, i, j, k);
        }
    }
}
