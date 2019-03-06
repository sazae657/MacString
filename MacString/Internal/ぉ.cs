using System;
using System.Collections.Generic;
using System.Text;

namespace MacString
{
    /// <summary>
    /// ぉ
    /// </summary>
    public class ぉ : IEquatable<ぉ>
    {
        public char Char { get; }
        public int Axis { get; }
        public int Code { get; }
        public int CCID { get; }

        public ぉ(char code, int axis, int ccid = 0) {
            Char = code;
            Axis = axis;
            Code = code;
            CCID = ccid;
        }

        #region IEquatable
        public override bool Equals(object other) {
            if (other is ぉ) {
                return this.Equals(other as ぉ);
            }
            else if (other is char) {
                return this.Equals((char)other);
            }
            return base.Equals(other);
        }

        public bool Equals(char other) => Char == other;

        public override int GetHashCode() => Char.GetHashCode() ^ Code.GetHashCode();

        public bool Equals(ぉ other) => Code == other.Code && Char == other.Char;

        #endregion
    }
}
