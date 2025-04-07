namespace CompositePattern.Pattern01
{
    public class ProductBundle : OrderItem
    {
        public List<OrderItem> Items {get; set;} = new List<OrderItem>();
        public decimal Discount { get; set; }
        public ProductBundle(string name, decimal dicount) : base(name)
        {
            Discount = dicount;
        }

        //     public string Name { get; set; }
        //     public List<SimpleProduct> Products {get; set;} = new List<SimpleProduct>();
        //     public decimal Discount {get; set;}

        //     public ProductBundle(string name, decimal discount)
        //     {
        //         Name = name;
        //         Discount = discount;
        //     }

        //     public void AddProduct(SimpleProduct product)
        //     {
        //         Products.Add(product);
        //     }

        //     public decimal GetPrice()
        //     {
        //         decimal total = 0;
        //         foreach(var product in Products)
        //         {
        //             total += product.GetPrice();
        //         }
        //         return total - Discount;
        //     }

        //     public double GetWeight()
        //     {
        //         double total = 0;
        //         foreach(var product in Products)
        //         {
        //             total += product.GetWeight();
        //         }
        //         return total;
        //     }

        //     public string GenerateInvoiceLine()
        // {
        //     var lines = new List<string> { $"Bundle: {Name}" };
        //     foreach (var product in Products)
        //     {
        //         lines.Add($"  - {product.GenerateInvoiceLine()}");
        //     }
        //     lines.Add($"  Bundle Discount: -{Discount:C}");
        //     lines.Add($"  Total: {GetPrice():C}");
        //     return string.Join("\n", lines);
        // }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public override string GenerateInvoiceLine(int indentLevel = 0)
        {
            var lines = new List<string> { $"{new string(' ', indentLevel * 2)}Bundle: {Name}" };
        foreach (var item in Items)
        {
            lines.Add(item.GenerateInvoiceLine(indentLevel + 1));
        }
        lines.Add($"{new string(' ', indentLevel * 2)}Bundle Discount: -{Discount:C}");
        lines.Add($"{new string(' ', indentLevel * 2)}Total: {GetPrice():C}");
        return string.Join("\n", lines);
        }

        public override int GetPrice()
        {
            int total = 0;
            foreach(var item in Items)
            {
                total += item.GetPrice();
            }
            return total - (int)Discount;
        }

        public override double GetWeight()
        {
            double total = 0;
        foreach (var item in Items)
        {
            total += item.GetWeight();
        }
        return total;
        }
    }
}