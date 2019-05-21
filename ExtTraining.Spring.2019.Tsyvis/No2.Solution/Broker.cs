namespace No2.Solution
{
    using System;

    public class Broker
    {
        public string Name { get; set; }

        private Stock stock;

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
        }

        public void Update(object sender, StockInfoEventArgs stockInfo)
        {
            Console.WriteLine(
                stockInfo.USD > 30
                    ? $"Broker {this.Name} sells dollars; Dollar rate: {stockInfo.USD}"
                    : $"Broker {this.Name} buys dollars; Dollar rate: {stockInfo.USD}");
        }

        public void StopTrade()
        {
            this.stock.StockChanged -= this.Update;
            this.stock = null;
        }
    }
}
