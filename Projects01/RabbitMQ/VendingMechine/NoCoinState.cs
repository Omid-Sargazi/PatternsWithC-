namespace RabbitMQ.VendingMechine
{
    public class NoCoinState
    {
        public void InsertCoin()
        {
            Console.WriteLine("سکه دریافت شد. حالا می‌تونی محصول انتخاب کنی.");
        }
        public void SelectItem()
        {
            Console.WriteLine("لطفاً اول سکه بنداز!");
        }
    }

    public class HasCoinState
    {
        public void InsertCoin()
        {
            Console.WriteLine("قبلاً سکه انداختی!");
        }

        public void SelectItem()
        {
            Console.WriteLine("محصول تحویل داده شد.");
        }
    }

    public class VendingMachine
    {
        private NoCoinState _noCoinState = new NoCoinState();
        private HasCoinState _hasCoinState = new HasCoinState();
        private object _currentState;

        public void InsertCoin()
        {
            if(_currentState is NoCoinState)
            {
                _hasCoinState.InsertCoin();
                _currentState = _hasCoinState;
            {
                _hasCoinState.InsertCoin();
            }
        }
        public void SelectItem()
        {
            if (_currentState is NoCoinState)
        {
            _noCoinState.SelectItem();
        }
        else if (_currentState is HasCoinState)
        {
            _hasCoinState.SelectItem();
            _currentState = _noCoinState; // بعد از تحویل محصول
        }
        }
    }
}