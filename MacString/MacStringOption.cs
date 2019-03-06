using System;
using System.Collections.Generic;
using System.Text;

namespace MacString
{
    /// <summary>
    /// ｵﾌﾟｼｮﾝ
    /// </summary>
    [Flags]
    public enum MacStringOption : uint
    {
        /// <summary>
        /// ﾃﾞﾌｫ
        /// </summary>
        Default = 0,

        /// <summary>
        /// 改行を Mac 化する
        /// </summary>
        NormalizeLineBreak = 0x00000001,

        /// <summary>
        /// 革新的に変換する
        /// </summary>
        InnovativeCombining = 0x00008000,
    }
}
