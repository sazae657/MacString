using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MacString;

namespace MacStringTest
{
    public class StringBuilderTest
    {
        [Fact]
        public void 仮名() {
            var sb = new StringBuilder();
            for (int i = 0; i < 例題.仮名.Length; ++i) {
                sb.AppendMac(例題.仮名[i].ToMac());
            }
            Assert.Equal(sb.ToString(), 例題.Mac.仮名);
        }

        [Fact]
        public void カナ() {
            var sb = new StringBuilder();
            for (int i = 0; i < 例題.カナ.Length; ++i) {
                sb.AppendMac(例題.カナ[i].ToMac());
            }
            Assert.Equal(sb.ToString(), 例題.Mac.カナ);
        }

        [Fact]
        public void 混在() {
            var div = 10;
            var len = 例題.例文.Length / div;
            var sb = new StringBuilder();
            int k = 0;
            for (int i = 0; i < div; ++i) {
                sb.AppendMac(例題.例文.Substring(k, len));
                k += len;
            }
            sb.AppendMac(例題.例文.Substring(k));
            Assert.Equal(sb.ToString(), 例題.Mac.例文);
        }

        [Fact]
        public void 個別() {
            var sb = new StringBuilder();
            foreach(var k in 例題.例文.ToCharArray()) {
                sb.AppendMac(k);
            }
            Assert.Equal(sb.ToString(), 例題.Mac.例文);
        }
    }
}
