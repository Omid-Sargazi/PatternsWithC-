namespace DesignPattern.StartegyPattern
{
    public interface ISortStrategy
    {
        void Sort(List<int> list);
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Bubble Sort");
            list.Sort();
        }
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Quick Sort");
            list.Sort();
        }
    }

    public class MergeSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Merge Sort");
            list.Sort();
        }
    }

    public class Sorter
    {
        private readonly ISortStrategy _sortStrategy;
        public Sorter(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void Sort(List<int> list)
        {
            _sortStrategy.Sort(list);
        }
    }
}