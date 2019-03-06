using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MacString.Internal;
namespace MacString
{
     /// <summary>
    /// string拡張
    /// </summary>
    public static class StringToMacExtension {

        /// <summary>
        /// NFDにして返す
        /// </summary>
        /// <param name="s"></param>
        /// <returns>文字列</returns>
        public static string ToMac(this char s, MacStringOption option = MacStringOption.Default) => InnovativeString.ToMac(s, option);


        /// <summary>
        /// NFDにして返す
        /// </summary>
        /// <param name="s"></param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <returns>文字列</returns>
        public static string ToMac(this string s, MacStringOption option = MacStringOption.Default) {
            if (s.Length == 1) {
                return InnovativeString.ToMac(s[0], option);
            }
            return InnovativeString.ToMac(s, option);
        }

    }
}
