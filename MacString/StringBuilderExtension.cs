using System;
using System.Collections.Generic;
using System.Text;

namespace MacString
{
    /// <summary>
    /// StringBuilder拡張
    /// </summary>
    public static class StringBuilderToMacExtension
    {
        /// <summary>
        /// NFD化して追記
        /// </summary>
        /// <param name="builder">ﾋﾞﾙﾀﾞー</param>
        /// <param name="value">値</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <returns></returns>
        public static StringBuilder AppendMac(this StringBuilder builder, string value, MacStringOption option = MacStringOption.Default)
            => builder.Append(value?.ToMac(option));

        /// <summary>
        /// NFD化して追記
        /// </summary>
        /// <param name="builder">ﾋﾞﾙﾀﾞー</param>
        /// <param name="value">値</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <returns></returns>
        public static StringBuilder AppendMac(this StringBuilder builder, char value, MacStringOption option = MacStringOption.Default)
            => builder.Append(value.ToMac(option));

    }
}
