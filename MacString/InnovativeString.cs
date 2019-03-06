using MacString.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MacString
{
    /// <summary>
    /// 文字列
    /// </summary>
    public static class InnovativeString
    {
        static readonly Regex 改行 = new Regex(@"\r?\n");

        /// <summary>
        /// 結合文字を返す
        /// </summary>
        /// <param name="id"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        private static char 結合文字(int id, MacStringOption option) =>
            option.HasFlag(MacStringOption.InnovativeCombining) ?
                MacCharTable.革新的結合文字[id] : MacCharTable.結合文字[id];

        /// <summary>
        /// charをNFDにする
        /// </summary>
        /// <param name="s"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static string ToMac(char s, MacStringOption option) {
            if (!MacCharTable.むあすつ.ContainsKey(s)) {
                return s.ToString();
            }
            var str = new char[2];
            var mu = MacCharTable.むあすつ[s];
            str[0] = (char)(s - mu.Axis);
            str[1] = 結合文字(mu.CCID, option);
            return new string(str);
        }

        /// <summary>
        /// 文字列をNFDにする
        /// </summary>
        /// <param name="s"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static string ToMac(string s, MacStringOption option = 0) {
            if (s.Length == 1) {
                return ToMac(s[0], option);
            }

            var mc = MacCharTable.超絶正規表現.Matches(s);
            if (mc.Count == 0) {
                if (option.HasFlag(MacStringOption.NormalizeLineBreak)) {
                    return 改行.Replace(s, MacConstant.NewLine.ToString());
                }
                return s;
            }
            int 前 = 0;
            var sb = new StringBuilder();
            foreach (Match m in mc) {
                if (m.Index != 0) {
                    sb.Append(s.Substring(前, m.Index - 前));
                }
                var mu = MacCharTable.むあすつ[s[m.Index]];
                sb.Append((char)(s[m.Index] - mu.Axis));
                sb.Append(結合文字(mu.CCID, option));
                前 = m.Index + m.Length;
            }
            if (前 != s.Length) {
                sb.Append(s.Substring(前));
            }

            if (option.HasFlag(MacStringOption.NormalizeLineBreak)) {
                return 改行.Replace(sb.ToString(), MacConstant.NewLine.ToString());
            }
            return sb.ToString();
        }
    }
}
