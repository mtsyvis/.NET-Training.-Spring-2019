namespace No2.Solution
{
    using System;

    public class Stock
    {
        private StockInfoEventArgs stocksInfo;

        public Stock(StockInfoEventArgs args)
        {
            this.stocksInfo = args;
        }

        public EventHandler<StockInfoEventArgs> StockChanged;
        
        public Stock() { }

        public void OnStockChanged()
        {
            var local = this.StockChanged;

            local?.Invoke(this, new StockInfoEventArgs(this.stocksInfo.USD, this.stocksInfo.Euro));
        }

        public void Market()
        {
            Random rnd = new Random();
            this.stocksInfo.USD = rnd.Next(20, 40);
            this.stocksInfo.Euro = rnd.Next(30, 50);
            this.OnStockChanged();
        }
    }
}
