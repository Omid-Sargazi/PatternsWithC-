using System.Globalization;

namespace PatternsInCSharp02.CommandPattern
{
    public interface IArtPiece
    {
        string ShowInfo();
        double GetValue();
    }

    public class Painting : IArtPiece
    {
        private string _name;
        private double _value;
        private int _year;
        public Painting(string name, double value, int year)
        {
            _name = name;
            _value = value;
            _year = year;
        }
        public double GetValue()
        {
            return _value;
        }

        public string ShowInfo()
        {
            return $"تابلو: {_name}, سال خلق: {_year}, ارزش: {_value} تومان";
        }
    }

    public class Gallery : IArtPiece
    {
        private string _name;
        private List<IArtPiece> _artPieces = new List<IArtPiece>();
        public Gallery(string name)
        {
            _name = name;
        } 

        public void Add(IArtPiece artPiece)
        {
            _artPieces.Add(artPiece);
        }
        public void Remove(IArtPiece artPiece)
        {
            _artPieces.Remove(artPiece);
        }
        public double GetValue()
        {
            double totalValue=0;
            foreach(var piece in _artPieces)
            {
                totalValue += piece.GetValue();
            }
            return totalValue;
        }

        public string ShowInfo()
        {
            string info = $"Gallery{_name}\n";
            foreach(var piece in _artPieces)
            {
                info += $"  -{piece.ShowInfo}";
            }
            return info;
        }
    }
}