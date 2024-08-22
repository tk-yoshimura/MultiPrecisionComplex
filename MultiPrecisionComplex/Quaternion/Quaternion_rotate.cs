using MultiPrecision;

namespace MultiPrecisionComplex {

    public partial class Quaternion<N> {

        public static Quaternion<N> FromAxisAngle((MultiPrecision<N> x, MultiPrecision<N> y, MultiPrecision<N> z) axis, MultiPrecision<N> angle) {
            MultiPrecision<N> half_angle = angle / 2;
            MultiPrecision<N> c = MultiPrecision<N>.Cos(half_angle), s = MultiPrecision<N>.Sin(half_angle);

            return new Quaternion<N>(c, s * axis.x, s * axis.y, s * axis.z);
        }

        public static Quaternion<N> FromYawPitchRoll(MultiPrecision<N> yaw, MultiPrecision<N> pitch, MultiPrecision<N> roll) {
            MultiPrecision<N> half_yaw = yaw / 2, half_pitch = pitch / 2, half_roll = roll / 2;

            MultiPrecision<N> cy = MultiPrecision<N>.Cos(half_yaw), sy = MultiPrecision<N>.Sin(half_yaw);
            MultiPrecision<N> cp = MultiPrecision<N>.Cos(half_pitch), sp = MultiPrecision<N>.Sin(half_pitch);
            MultiPrecision<N> cr = MultiPrecision<N>.Cos(half_roll), sr = MultiPrecision<N>.Sin(half_roll);

            return new Quaternion<N>(
                cy * cp * cr + sy * sp * sr,
                cy * sp * cr + sy * cp * sr,
                sy * cp * cr - cy * sp * sr,
                cy * cp * sr - sy * sp * cr
            );
        }
    }
}
