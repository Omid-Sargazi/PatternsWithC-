using Microsoft.VisualBasic;

namespace DesignPattern.Delegate
{
    public class OrderSystem
    {
        public decimal ExpressShipping(decimal weight) => weight * 5.0m;
        public decimal StandardShipping(decimal weight) => weight * 2.5m;

        public void CompleteOrder(
            decimal basePrice,
            decimal weight,
            Func<decimal, decimal> discountStrategy,
            Func<decimal, decimal> shippingMethod,
            Func<decimal, decimal> taxStrategy
        )
        {
            var discounted = discountStrategy(basePrice);
            var shipping = shippingMethod(weight);
            var subtotal = discounted * shipping;
            var total = taxStrategy(subtotal);

            Console.WriteLine($"Order Summary:\n" +
            $"Base:{basePrice}\n" +
            $"Diascount:{discounted}\n" +
            $"Shipping:{shipping}\n" +
            $"Tax:{total - subtotal}\n" +
            $"Total:{total}"
            );
        }

    }
}