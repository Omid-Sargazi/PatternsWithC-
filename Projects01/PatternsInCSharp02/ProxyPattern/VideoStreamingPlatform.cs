namespace PatternsInCSharp02.ProxyPattern
{
    public interface IVideo
    {
        void Play();
    }

    public class RealVideo : IVideo
    {
        private string _title;
        public RealVideo(string title)
        {
            _title = title;
            LoadVideoFromServer();
        }

        private void LoadVideoFromServer()
        {
            Console.WriteLine($"Loading video: {_title} from server...");
        }
        public void Play()
        {
            Console.WriteLine($"Playing video: {_title}");
        }
    }

    public class ProxyVideo : IVideo
    {
        private string _title;
        private RealVideo _realVideo;
        private bool _isSubscribed;

        public ProxyVideo(string title, bool isSubscribed)
        {
            _title = title;
            _isSubscribed = isSubscribed;
        }

        public void Play()
        {
            if(!_isSubscribed)
            {
                Console.WriteLine("Access denied. Please subscribe to watch premium content.");
                return;
            }else if(_realVideo==null)
            {
                _realVideo = new RealVideo(_title);
            }
            _realVideo.Play();
        }
    }
}