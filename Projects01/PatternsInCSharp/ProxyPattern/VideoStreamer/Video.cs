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

    public class VideoStreamer
    {
        private readonly string _videoId;
        private Video _video;
        public VideoStreamer(string videoId)
        {
            _videoId = videoId;
            _video = LoadVideoFromServer(videoId);
        }


        private Video LoadVideoFromServer(string videoId)
        {
            Console.WriteLine($"Loading video {videoId} from server...");
            Thread.Sleep(3000); // ۳ ثانیه تاخیر
            return new Video("Sample Video", 120, "Heavy 4K video data...");
        }

        public string GetTitle()
        {
            return _video.Title;
        }

        public int GetDuration()
        {
            return _video.DurationInSeconds;
        }

        public string StreamVideo()
        {
            return _video.VideoDate;
        }
    }
}
