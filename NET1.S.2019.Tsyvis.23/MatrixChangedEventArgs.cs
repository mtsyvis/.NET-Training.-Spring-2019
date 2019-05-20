using System;

namespace NET1.S._2019.Tsyvis._23
{
    public class MatrixChangedEventArgs<T> : EventArgs where T : struct
    {
        public int I { get; set; }
        public int J { get; set; }
        public T Value { get; set; }
    }
}
