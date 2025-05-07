using System.Text.Json.Nodes;

namespace BehavioralPattern.VisitorCompositePattern
{
    public interface IReport
    {
        void Accept(IReportVisitor visitor);
    }

    public interface IReportVisitor
    {
        void Visit(SalesReport report);
        void Visit(InventoryReport report);
    }

    public class SalesReport : IReport
    {
        public decimal TotalSales {get; set;}
        public SalesReport(decimal totalSales)
        {
            TotalSales = totalSales;
        }
        public void Accept(IReportVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class InventoryReport : IReport
    {
        public int StockLevel {get; set;}
        public InventoryReport(int stockLevel)
        {
            StockLevel = stockLevel;
        }
        public void Accept(IReportVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class JsonVisitor : IReportVisitor
    {
        public string Result {get; private set;} = "";
        public void Visit(SalesReport report)
        {
            Result = $"{{ \"type\": \"Sales\", \"totalSales\": {report.TotalSales} }}";
        }

        public void Visit(InventoryReport report)
        {
            Result = $"{{ \"type\": \"Inventory\", \"stockLevel\": {report.StockLevel} }}";
        }
    }

    public class XmlVisitor : IReportVisitor
    {
        public string Result {get; private set;} = "";
        public void Visit(SalesReport report)
        {
           Result = $"<Report><Type>Sales</Type><TotalSales>{report.TotalSales}</TotalSales></Report>";
        }

        public void Visit(InventoryReport report)
        {
            Result = $"<Report><Type>Inventory</Type><StockLevel>{report.StockLevel}</StockLevel></Report>";
        }
    }
}