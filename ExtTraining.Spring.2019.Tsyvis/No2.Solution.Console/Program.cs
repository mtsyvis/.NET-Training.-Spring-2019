using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var startStock = new StockInfoEventArgs(10, 20);
            var stock = new Stock(startStock);

            var bank = new Bank("Bank");
            var broker = new Broker("Broker", stock);

            stock.StockChanged += bank.Update;
            stock.StockChanged += broker.Update;
            stock.Market();

            System.Console.ReadLine();
        }
    }
}
