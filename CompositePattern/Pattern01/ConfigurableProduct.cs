namespace CompositePattern.Pattern01
{
   public class ConfigurableProduct : OrderItem
{
    public int BasePrice { get; set; }
    public double BaseWeight { get; set; }
    public List<(string OptionName, int ExtraPrice, double ExtraWeight)> SelectedOptions { get; set; } = new List<(string, int, double)>();

    public ConfigurableProduct(string name, int basePrice, double baseWeight) : base(name)
    {
        BasePrice = basePrice;
        BaseWeight = baseWeight;
    }

    public void AddOption(string optionName, int extraPrice, double extraWeight)
    {
        SelectedOptions.Add((optionName, extraPrice, extraWeight));
    }

    public override int GetPrice()
    {
        int total = BasePrice;
        foreach (var option in SelectedOptions)
        {
            total += option.ExtraPrice;
        }
        return total;
    }

    public override double GetWeight()
    {
        double total = BaseWeight;
        foreach (var option in SelectedOptions)
        {
            total += option.ExtraWeight;
        }
        return total;
    }

    public override string GenerateInvoiceLine(int indentLevel)
    {
        var lines = new List<string> { $"{new string(' ', indentLevel * 2)}{Name}: {BasePrice:C}" };
        foreach (var option in SelectedOptions)
        {
            lines.Add($"{new string(' ', (indentLevel + 1) * 2)}Option: {option.OptionName} (+{option.ExtraPrice:C})");
        }
        lines.Add($"{new string(' ', indentLevel * 2)}Total: {GetPrice():C}");
        return string.Join("\n", lines);
    }
}
}