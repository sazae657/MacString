using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MacString
{
    /// <summary>
    /// StreamWriter拡張
    /// </summary>
    public static class StreamWriterAsMacExtension
    {
        /// <summary>
        /// NFDで書き込む
        /// </summary>
        /// <param name="writer">ライター</param>
        /// <param name="value">値</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        public static void WriteMac(this StreamWriter writer, string value, MacStringOption option = MacStringOption.Default)
            => writer.Write(value.ToMac(option));

        /// <summary>
        /// NFD+改行で書き込む
        /// </summary>
        /// <param name="writer">ライター</param>
        /// <param name="value">値</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        public static void WriteLineMac(this StreamWriter writer, string value, MacStringOption option = MacStringOption.Default)
            => writer.Write((value + System.Environment.NewLine).ToMac(option));

        /// <summary>
        /// NFDで書き込む
        /// </summary>
        /// <param name="writer">ライター</param>
        /// <param name="value">値</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        public static void WriteMac(this StreamWriter writer, char value, MacStringOption option = MacStringOption.Default)
            => writer.Write(value.ToMac(option));
    }

    /// <summary>
    /// StreamReader拡張
    /// </summary>
    public static class StreamReaderAsMacExtension
    {
        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="reader">ローダー</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <return></return>
        public static string ReadMac(this StreamReader reader, MacStringOption option = MacStringOption.Default) {
            var r = reader.Read();
            if (r < 0) {
                return null;
            }
            return ((char)r).ToMac(option);
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="reader">ローダー</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <return></return>
        public static string ReadLineMac(this StreamReader reader, MacStringOption option = MacStringOption.Default)
            => reader.ReadLine()?.ToMac(option);

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="reader">ローダー</param>
        /// <param name="option">ｵﾌﾟｼｮﾝ</param>
        /// <return></return>
        public static string ReadToEndMac(this StreamReader reader, MacStringOption option = MacStringOption.Default)
            => reader.ReadToEnd()?.ToMac(option);

    }
}
