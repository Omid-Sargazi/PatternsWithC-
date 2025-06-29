namespace DesignPattern.StartegyPattern
{
    public interface ITaxCalculate
    {
        decimal Calculate(decimal amount);
    }

    public class GermanyTaxCalculate : ITaxCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount + amount * 0.09m;
        }
    }


    public class IranTaxCalculate : ITaxCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount + amount * 0.19m;
        }
    }

    public class USATaxCalculate : ITaxCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount + amount * .01m;
        }
    }



    public class TaxCalculate
    {
        private readonly ITaxCalculate _taxCalculate;
        public TaxCalculate(ITaxCalculate taxCalculate)
        {
            _taxCalculate = taxCalculate;
        }

        public void CalculateTax(decimal amount)
        {
            _taxCalculate.Calculate(amount);
        }
    }
}