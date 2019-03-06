using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MacString;

namespace MacStringTest
{
    public class InnovativeTest
    {
        [Fact]
        public void 全文字() {
            var nfc = 例題.仮名;
            var nfd = InnovativeString.ToMac(nfc);

            Assert.NotEqual(nfc, nfd);
            Assert.Equal(nfd.Length, (nfc.Length * 2));
            Assert.Equal(nfd, 例題.Mac.仮名);
            Assert.Equal(InnovativeString.ToMac(例題.Mac.仮名), 例題.Mac.仮名);

            nfc = 例題.カナ;
            nfd = nfc.ToMac();
            Assert.NotEqual(nfc, nfd);
            Assert.Equal(nfd.Length, (nfc.Length * 2));
            Assert.Equal(nfd, 例題.Mac.カナ);

            Assert.Equal(InnovativeString.ToMac(例題.Mac.カナ), 例題.Mac.カナ);
        }

    }
}
