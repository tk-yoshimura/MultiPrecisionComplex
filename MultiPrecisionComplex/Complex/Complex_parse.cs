using MultiPrecision;
using MultiPrecisionComplex.Util;
using System.Diagnostics.CodeAnalysis;

namespace MultiPrecisionComplex {

    public partial class Complex<N> : IParsable<Complex<N>> {
        public static Complex<N> Parse(string s) {
            if (string.IsNullOrEmpty(s) || s.Length < 1) {
                throw new FormatException($"Invalid numeric string. : {s}");
            }

            (MultiPrecision<N> v, bool set) r = (MultiPrecision<N>.Zero, false), i = (MultiPrecision<N>.Zero, false);

            int index_e0 = (s[0] == '+' || s[0] == '-') ? 1 : 0;
            int index_e1 = ParseUtil.IndexOfElem(s, index_e0);

            string e0 = (index_e1 > 0) ? s[..index_e1] : s;
            string e1 = (index_e1 > 0) ? s[index_e1..] : string.Empty;

            ValidateElem(e0, out MultiPrecision<N> v0, out char s0);
            ValidateElem(e1, out MultiPrecision<N> v1, out char s1);

            if (s0 == 'r') {
                r = (v0, true);
            }
            else if (s0 == 'i') {
                i = (v0, true);
            }

            if (s1 == 'r') {
                if (r.set) {
                    throw new FormatException($"Invalid numeric string. : {s}");
                }

                r = (v1, true);
            }
            else if (s1 == 'i') {
                if (i.set) {
                    throw new FormatException($"Invalid numeric string. : {s}");
                }

                i = (v1, true);
            }

            return new Complex<N>(r.v, i.v);
        }

        public static Complex<N> Parse(string s, IFormatProvider provider) {
            return Parse(s);
        }

        public static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, [MaybeNullWhen(false)] out Complex<N> result) {
            try {
                result = Parse(s);
                return true;
            }
            catch (FormatException) {
                result = Zero;
                return false;
            }
        }

        private static void ValidateElem(string s, out MultiPrecision<N> v, out char symbol) {
            if (string.IsNullOrEmpty(s)) {
                (v, symbol) = (MultiPrecision<N>.Zero, '_');
            }
            else {
                (v, symbol) = s[^1] switch {
                    'i' => (s[..^1], 'i'),
                    >= '0' and <= '9' => (s, 'r'),
                    _ => throw new FormatException($"Invalid numeric string. : {s}")
                };
            }
        }
    }
}
