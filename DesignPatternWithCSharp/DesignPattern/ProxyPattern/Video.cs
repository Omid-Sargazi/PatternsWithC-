namespace DesignPattern.ProxyPattern
{
    public class Video
    {
        public string FileName { get; set; }
        public Video(string fileName)
        {
            FileName = fileName;
            Console.WriteLine($"[Loading video from disk: {FileName}]");
            Thread.Sleep(2000); // simulate loading
        }

        public void Play()
        {
            Console.WriteLine($"Playing video: {FileName}");
        }
    }

    public class VideoProxy
    {
        private string FileName { get; set; }
        private Video realVideo;

        public VideoProxy(string fileName)
        {
            FileName = fileName;
        }

        public void Play()
        {
            if (realVideo == null)
                realVideo = new Video(FileName);
            realVideo.Play();
            
        }
    }
}