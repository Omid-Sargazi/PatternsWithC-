namespace DesignPattern.Delegate
{
    public class ProductRating
    {
        private List<int> _ratings = new();
        public delegate void RatingAdded(int newRating);

        public event RatingAdded OnRatingAdded;

        public void AddRating(int rating)
        {
            _ratings.Add(rating);
            OnRatingAdded?.Invoke(rating);
        }

        public double Calculate(Func<IEnumerable<int>, double> calculationMethod)
        {
            return calculationMethod(_ratings);
        }
    }
}