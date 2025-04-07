namespace CompositePattern.Pattern01
{
    public class ProductBundle
    {
        public string Name { get; set; }
        public List<SimpleProduct> Products {get; set;} = new List<SimpleProduct>();
        public decimal Discount {get; set;}

        public ProductBundle(string name, decimal discount)
        {
            Name = name;
            Discount = discount;
        }
        
        public void AddProduct(SimpleProduct product)
        {
            Products.Add(product);
        }

        public decimal GetPrice()
        {
            decimal total = 0;
            foreach(var product in Products)
            {
                total += product.GetPrice();
            }
            return total - Discount;
        }

        public double GetWeight()
        {
            double total = 0;
            foreach(var product in Products)
            {
                total += product.GetWeight();
            }
            return total;
        }

        public string GenerateInvoiceLine()
    {
        var lines = new List<string> { $"Bundle: {Name}" };
        foreach (var product in Products)
        {
            lines.Add($"  - {product.GenerateInvoiceLine()}");
        }
        lines.Add($"  Bundle Discount: -{Discount:C}");
        lines.Add($"  Total: {GetPrice():C}");
        return string.Join("\n", lines);
    }
    }
}