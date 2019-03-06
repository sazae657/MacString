using System;
using Xunit;
using MacString;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MacStringTest
{
    public class StreamTest
    {
        [Fact]
        public void 混在() {
            using (var ms = new MemoryStream()) {
                using (var sw = new StreamWriter(ms, Encoding.Unicode)) {
                    sw.WriteMac(例題.例文);
                }
                ms.Close();
                var ar = ms.ToArray();
                var ss = Encoding.Unicode.GetString(ms.ToArray(), 2,ar.Length - 2);
                Assert.Equal(ss, 例題.Mac.例文);
            }
        }

        [Fact]
        public void 個別() {
            using (var ms = new MemoryStream()) {
                using (var sw = new StreamWriter(ms, Encoding.Unicode)) {
                    foreach(var k in 例題.例文.ToCharArray()) {
                        sw.WriteMac(k);
                    }
                }
                ms.Close();
                var ar = ms.ToArray();
                var ss = Encoding.Unicode.GetString(ms.ToArray(), 2,ar.Length - 2);
                Assert.Equal(ss, 例題.Mac.例文);
            }
        }

        [Fact]
        public void 改行() {
            using (var ms = new MemoryStream()) {
                using (var sw = new StreamWriter(ms, Encoding.Unicode)) {
                    sw.NewLine = "\r";
                    foreach (var m in Regex.Split(例題.例文2, @"\r?\n")) {
                        sw.WriteLineMac(m, MacStringOption.NormalizeLineBreak);
                    }
                }
                ms.Close();
                var ar = ms.ToArray();
                var ss = Encoding.Unicode.GetString(ms.ToArray(), 2, ar.Length - 4);
                Assert.Equal(ss, 例題.Mac.例文2);
            }
        }


        [Fact]
        public void 混在読み込み() {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(例題.例文))) {
                string s = null;
                using (var sr = new StreamReader(ms, Encoding.Unicode)) {
                    s = sr.ReadToEndMac();
                }
                Assert.Equal(s, 例題.Mac.例文);
            }
        }

        [Fact]
        public void 文字読み込み() {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(例題.例文))) {
                var s = new StringBuilder();
                using (var sr = new StreamReader(ms, Encoding.Unicode)) {
                    string k = null;
                    while(null != (k = sr.ReadMac())){
                        s.Append(k);
                    }
                }
                Assert.Equal(s.ToString(), 例題.Mac.例文);
            }
        }

        [Fact]
        public void 行読み込み() {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(例題.例文2))) {
                var s = new StringBuilder();
                using (var sr = new StreamReader(ms, Encoding.Unicode)) {
                    string k = null;
                    while(null != (k = sr.ReadLineMac())){
                        s.Append(k).Append('\r');
                    }
                }
                Assert.Equal(s.ToString(), (例題.Mac.例文2 + "\r"));
            }
        }
    }
}
