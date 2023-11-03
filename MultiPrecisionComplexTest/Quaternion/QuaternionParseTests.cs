﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPrecision;
using MultiPrecisionComplex;

namespace MultiPrecisionComplexTests {
    [TestClass()]
    public class QuaternionParseTests {
        [TestMethod()]
        public void NormalTest() {
            foreach ((MultiPrecision<Pow2.N8> v, string s) r in new[] {
                (0, ""), (1, "1"), (-1, "-1"), (+1, "+1"),
                (+0.25, "+0.25"), (-0.25, "-0.25"), (+0.125, "+1.25e-1"), (125, "+1.25e+2") }) {

                foreach ((MultiPrecision<Pow2.N8> v, string s) i in new[] {
                    (0, ""), (2, "2i"), (-2, "-2i"), (+2, "+2i"),
                    (+0.25, "+0.25i"), (-0.25, "-0.25i"), (+0.125, "+1.25e-1i"), (125, "+1.25e+2i") }) {
                    if (r.s != "" && i.s == "2i") {
                        continue;
                    }

                    foreach ((MultiPrecision<Pow2.N8> v, string s) j in new[] {
                        (0, ""), (3, "3j"), (-3, "-3j"), (+3, "+3j"),
                        (+0.25, "+0.25j"), (-0.25, "-0.25j"), (+0.125, "+1.25e-1j"), (125, "+1.25e+2j") }) {

                        if ((r.s != "" || i.s != "") && j.s == "3j") {
                            continue;
                        }

                        foreach ((MultiPrecision<Pow2.N8> v, string s) k in new[] {
                            (0, ""), (4, "4k"), (-4, "-4k"), (+4, "+4k"),
                            (+0.25, "+0.25k"), (-0.25, "-0.25k"), (+0.125, "+1.25e-1k"), (125, "+1.25e+2k") }) {

                            if ((r.s != "" || i.s != "" || j.s != "") && k.s == "4k") {
                                continue;
                            }

                            string s = $"{r.s}{i.s}{j.s}{k.s}";

                            if (string.IsNullOrEmpty(s)) {
                                continue;
                            }

                            Console.WriteLine(s);

                            Quaternion<Pow2.N8> q = s;
                            Assert.AreEqual(new Quaternion<Pow2.N8>(r.v, i.v, j.v, k.v), q, s);
                        }
                    }
                }
            }

            Quaternion<Pow2.N8> q1 = "+4k+1+3j+2i";
            Assert.AreEqual(new Quaternion<Pow2.N8>(1, 2, 3, 4), q1);

            Quaternion<Pow2.N8> q2 = "+4k+3j+2i";
            Assert.AreEqual(new Quaternion<Pow2.N8>(0, 2, 3, 4), q2);
        }

        [TestMethod()]
        public void BadParseTest() {
            string[] tests = {
                "",
                "+",
                "-",
                "++",
                "+-",
                "--",
                "-+",
                "+1-",
                "+1+i",
                "+1++i",
                "+1+-i",
                "1+i",
                "i",
                "1i+",
                "1i+1i",
                "2+2",
                "2+2i-",
                "2+2i-2i",
                "2+2i-2",
                "2+2p",
                "2+2e",
                "2+2e1",
                "2+e",
                "e",
                "2+2jk",
                "2+2j+2k+2k",
                "2+2j+2k+2k+1i",
                "2+2j++2k+2k+1i",
                "2+2j++2k+2k+ei",
                "+4k+1+3j+2i+"
            };

            foreach (string test in tests) {
                Console.WriteLine(test);

                Assert.ThrowsException<FormatException>(() => {
                    Quaternion<Pow2.N8> _ = test;
                });
            }
        }
    }
}