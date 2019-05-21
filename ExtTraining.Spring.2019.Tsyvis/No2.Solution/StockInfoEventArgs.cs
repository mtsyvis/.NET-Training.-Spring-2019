namespace No2.Solution
{
    using System;

    public class StockInfoEventArgs : EventArgs
    {
        public int USD { get; set; }
        public int Euro { get; set; }
            
        public StockInfoEventArgs(int USD, int Euro)
        {
            this.Euro = Euro;
            this.USD = USD;
        }
    }
}
