using System;
using Xunit;
using MacString;

namespace MacStringTest
{
    public class StrringTest
    {
        [Fact]
        public void 全文字() {
            var nfc = 例題.仮名;
            var nfd = nfc.ToMac();

            Assert.NotEqual(nfc, nfd);
            Assert.Equal(nfd.Length, (nfc.Length * 2));
            Assert.Equal(nfd, 例題.Mac.仮名);
            Assert.Equal(例題.Mac.仮名.ToMac(), 例題.Mac.仮名);

            nfc = 例題.カナ;
            nfd = nfc.ToMac();
            Assert.NotEqual(nfc, nfd);
            Assert.Equal(nfd.Length, (nfc.Length * 2));
            Assert.Equal(nfd, 例題.Mac.カナ);

            Assert.Equal(例題.Mac.カナ.ToMac(), 例題.Mac.カナ);
        }

        [Fact]
        public void 単発仮名() {
            for (int i = 0; i < 例題.仮名.Length; ++i) {
                var c = 例題.仮名[i].ToMac();
                Assert.Equal(c, 例題.Mac.仮名.Substring(i * 2, 2));
            }
        }

        [Fact]
        public void 単発カナ() {
            for (int i = 0; i < 例題.カナ.Length; ++i) {
                var c = 例題.カナ[i].ToMac();
                Assert.Equal(c, 例題.Mac.カナ.Substring(i * 2, 2));
            }
        }

        [Fact]
        public void 混在() {
            var nfd = 例題.例文.ToMac();
            Assert.Equal(nfd, 例題.Mac.例文);
        }

        [Fact]
        public void 改行() {
            Assert.Equal(例題.例文2.ToMac(), 例題.Mac.例文2.Replace("\r", "\r\n"));
        }

        [Fact]
        public void 改行変換() {
            Assert.Equal(例題.例文2.ToMac(MacStringOption.NormalizeLineBreak), 例題.Mac.例文2);
        }

        [Fact]
        public void 先頭() {
            var s = "ゆ";
            Assert.Equal(s.ToMac(), s);

            s = "ずこ";
            var ac = "ずこ";
            Assert.Equal(s.ToMac(), ac);
        }

        [Fact]
        public void 末尾() {
            var s = "おゆ";
            Assert.Equal(s.ToMac(), s);

            s = "ゆず";
            var ac = "ゆず";
            Assert.Equal(s.ToMac(), ac);
        }

        [Fact]
        public void 挟み() {
            var s = "にげん";
            var ac = "にげん";
            Assert.Equal(s.ToMac(), ac);
        }
    }
}
