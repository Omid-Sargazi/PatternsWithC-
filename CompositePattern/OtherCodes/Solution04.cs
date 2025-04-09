namespace CompositePattern.OtherCodes
{
    public class Solution04
    {
        public int MaxProfit(int[] prices)
        {
            if(prices.Length<2) return 0;
            int maxProfit = 0;
            int minPrice = prices[0];
            for(int i=1; i<prices.Length; i++)
            {
                if(prices[i]<minPrice)
                {
                    minPrice = prices[i];
                }
                else{
                    int profit = prices[i] - minPrice;
                    if(profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit;
        }
    }
}