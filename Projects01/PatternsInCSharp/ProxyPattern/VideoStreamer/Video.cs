namespace PatternsInCSharp.ProxyPattern.VideoStreamer
{
    public class Video
    {
        public string Title {get;}
        public int DurationInSeconds {get;}
        public string VideoDate {get;}
        
        public Video(string title, int durationInSeconds, string videoDate)
        {
            Title = title;
            DurationInSeconds = durationInSeconds;
            VideoDate = videoDate;
        }

        public string GetVideoInfo()
        {
            return $"Title: {Title}, Duration: {DurationInSeconds} seconds, Date: {VideoDate}";
        }
    }

    public interface IVideoStreamer
    {
        string GetTitle();
        int GetDuration();
        string StreamVideo();
    }

    public class VideoStreamer : IVideoStreamer
    {
        private readonly string _videoId;
        private Video _video;
        public VideoStreamer(string videoId)
        {
            _videoId = videoId;
            
        }


        private Video LoadVideoFromServer()
        {
            Console.WriteLine($"Loading video {_videoId} from server...");
            Thread.Sleep(3000); // ۳ ثانیه تاخیر
            return new Video("Sample Video", 120, "Heavy 4K video data...");
        }

        public string GetTitle()
        {
            _video ??= LoadVideoFromServer();
            return _video.Title;
        }

        public int GetDuration()
        {
            _video ??= LoadVideoFromServer();
            return _video.DurationInSeconds;
        }

        public string StreamVideo()
        {
            _video ??= LoadVideoFromServer();
            return _video.VideoDate;
        }
    }

    public class VideoProxyStreamer : IVideoStreamer
    {
        private Video _video;
        private readonly string _videoId;
        private VideoStreamer _videoStreamer;
        private readonly bool _isVipUser;
        public VideoProxyStreamer(string videoId, bool isVipUser)
        {
            _videoId = videoId;
            _isVipUser = isVipUser;
            _video = new Video("Sample Video",120, null);
        }
        public int GetDuration()
        {
            return _video.DurationInSeconds;
        }

        public string GetTitle()
        {
            return _video.Title;
        }

        public string StreamVideo()
        {
            if(!_isVipUser)
            {
                return "You need to be a VIP user to stream this video.";
            }
            _videoStreamer ??= new VideoStreamer(_videoId);
            return _videoStreamer.StreamVideo();
        }
    }
}
