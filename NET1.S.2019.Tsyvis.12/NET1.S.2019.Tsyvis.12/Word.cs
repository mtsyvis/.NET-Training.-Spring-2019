using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12
{
    public class Word : IEquatable<Word>
    {
        public string Value { get; set; }

        public int Count { get; set; }

        public bool Equals(Word other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.Value, other.Value) && this.Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Word)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Value != null ? this.Value.GetHashCode() : 0) * 397) ^ this.Count;
            }
        }
    }
}
