using MultiPrecision;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MultiPrecisionComplex {

    public partial class Octonion<N> : IParsable<Octonion<N>> {
        public static Octonion<N> Parse(string s) {
            if (string.IsNullOrEmpty(s) || s.Length < 1 || s.Contains('|') || s.Contains('#')) {
                throw new FormatException($"Invalid numeric string. : {s}");
            }

            StringBuilder str = new(s.ToLower());
            s = str.Replace("e+", "#P").Replace("e-", "#M").Replace("+", "|+").Replace("-", "|-").Replace("#P", "e+").Replace("#M", "e-").ToString();

            string[] terms = s.Split("|", StringSplitOptions.RemoveEmptyEntries);

            MultiPrecision<N>[] elems = Enumerable.Repeat(MultiPrecision<N>.Zero, 8).ToArray();
            bool[] elem_sets = new bool[8];

            foreach (string term in terms) {
                ValidateElem(term, out MultiPrecision<N> v, out int index_elem);

                if (elem_sets[index_elem]) {
                    throw new FormatException($"Invalid numeric string. : {s}");
                }

                if (index_elem >= 0) {
                    elems[index_elem] = v;
                    elem_sets[index_elem] = true;
                }
            }

            if (!elem_sets.Any(b => b)) {
                throw new FormatException($"Invalid numeric string. : {s}");
            }

            Octonion<N> o = new(elems[0], elems[1], elems[2], elems[3], elems[4], elems[5], elems[6], elems[7]);

            return o;
        }

        public static Octonion<N> Parse(string s, IFormatProvider provider) {
            return Parse(s);
        }

        public static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, [MaybeNullWhen(false)] out Octonion<N> result) {
            try {
                result = Parse(s);
                return true;
            }
            catch (FormatException) {
                result = Zero;
                return false;
            }
        }

        private static void ValidateElem(string s, out MultiPrecision<N> v, out int index_elem) {
            if (string.IsNullOrEmpty(s)) {
                (v, index_elem) = (MultiPrecision<N>.Zero, -1);
            }
            else {
                (v, index_elem) = s[^1] switch {
                    'i' => (s[..^1], 1),
                    'j' => (s[..^1], 2),
                    'k' => (s[..^1], 3),
                    'w' => (s[..^1], 4),
                    'x' => (s[..^1], 5),
                    'y' => (s[..^1], 6),
                    'z' => (s[..^1], 7),
                    >= '0' and <= '9' => (s, 0),
                    _ => throw new FormatException($"Invalid numeric string. : {s}")
                };
            }
        }
    }
}
