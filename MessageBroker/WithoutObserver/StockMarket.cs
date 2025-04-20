namespace MessageBroker.WithoutObserver
{
    public class StockMarket
    {
       public void UpdateStockPrice(string symbol, decimal price)
       {
             SavePriceToDatabase(symbol, price);
        
        // اطلاع‌رسانی به همه سیستم‌ها
            UpdateMobileApp(symbol, price);
            UpdateDisplayBoard(symbol, price);
            SendPriceAlerts(symbol, price);
            
            Console.WriteLine($"قیمت سهام {symbol} به {price} تغییر کرد.");
       }

       private void SavePriceToDatabase(string symbol, decimal price)
       {
             Console.WriteLine($"ذخیره قیمت {symbol} در دیتابیس: {price}");
       }

       private void UpdateMobileApp(string symbol, decimal price)
        {
            Console.WriteLine($"به‌روزرسانی اپلیکیشن موبایل برای سهام {symbol}: {price}");
        }
        
        private void UpdateDisplayBoard(string symbol, decimal price)
        {
            Console.WriteLine($"به‌روزرسانی تابلوی نمایش برای سهام {symbol}: {price}");
        }
        
        private void SendPriceAlerts(string symbol, decimal price)
        {
            Console.WriteLine($"ارسال هشدار قیمت برای سهام {symbol}: {price}");
        }
    }
}