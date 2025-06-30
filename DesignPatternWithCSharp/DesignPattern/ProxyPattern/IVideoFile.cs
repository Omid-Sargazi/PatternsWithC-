namespace DesignPattern.ProxyPattern
{
    public interface IVideoFilee
    {
        void Play();
        string GetInfo();
    }

    public class RealVideoFile : IVideoFilee
    {
        public string FileName { get; private set; }
        public int SizeInMB { get; private set; }
        public byte[] Data { get; private set; }

        public RealVideoFile(string fileName, int sizeInMB)
        {
            FileName = fileName;
            SizeInMB = sizeInMB;
            DownloadFromServer();
        }

        private void DownloadFromServer()
        {

        }
        public string GetInfo()
        {
            return $"{FileName} ({SizeInMB}MB) - Downloaded";
        }

        public void Play()
        {
            Console.WriteLine($"🎬 Playing {FileName}...");
        }
    }

    public class VideoFileProxy : IVideoFilee
    {
        private readonly RealVideoFile _realVideoFile;
        private readonly string _fileName;
        private readonly int _sizeInMB;
        private readonly string _userRole;

        private static Dictionary<string, RealVideoFile> _cache = new Dictionary<string, RealVideoFile>();
        public VideoFileProxy(string fileName, int sizeInMB, string userRole = "user")
        {
            _fileName = fileName;
            _sizeInMB = sizeInMB;
            _userRole = userRole;
        }
        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}