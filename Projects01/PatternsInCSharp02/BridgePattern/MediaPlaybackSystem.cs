namespace PatternsInCSharp02.BridgePattern
{
   public enum PlaybackStatus
   {
        Success,
        Failed,
   }

   public class MediaDetails
   {
        public string Title {get; set;}
        public int Duration {get; set;}
        public MediaDetails(string title, int duration)=>(Title, Duration)=(title, duration);
   }

   public interface IPlaybackPlatform
   {
        PlaybackStatus ExecutePlayback(MediaDetails mediaDetails);
        bool IsAvailable();
   }

   public abstract class MediaBase
   {
        protected MediaDetails _details;
        protected MediaBase(MediaDetails details)
        {
            _details = details;
        }

        public abstract bool ValidateMedia();
        public MediaDetails GetDetails=> _details;
   }

    public class MusicMedia : MediaBase
    {
        public MusicMedia(MediaDetails details) : base(details)
        {
        }

        public override bool ValidateMedia()
        {
           return _details.Duration>0 && _details.Duration <=600;
        }
    }

    public class VideoMedia : MediaBase
    {
        public VideoMedia(MediaDetails details) : base(details)
        {
        }

        public override bool ValidateMedia()
        {
            return _details.Duration>0 && _details.Duration<=7200;
        }
    }

    public class WebPlayer : IPlaybackPlatform
    {
        public PlaybackStatus ExecutePlayback(MediaDetails mediaDetails)
        {
            return mediaDetails.Title.Length > 0 ? PlaybackStatus.Success : PlaybackStatus.Failed;
        }

        public bool IsAvailable()
        {
            return true;
        }
    }

    public class MobilePlayer : IPlaybackPlatform
    {
        public PlaybackStatus ExecutePlayback(MediaDetails mediaDetails)
        {
            return mediaDetails.Duration > 0 ? PlaybackStatus.Success : PlaybackStatus.Failed;
        }

        public bool IsAvailable()
        {
            return true;
        }
    }

    public class MediaPlayer
    {
        public PlaybackStatus Play(MediaBase media, IPlaybackPlatform platform)
        {
            if (!platform.IsAvailable() || !media.ValidateMedia())
                return PlaybackStatus.Failed;

            PlaybackStatus status = platform.ExecutePlayback(media.GetDetails());
            Console.WriteLine($"Playing {media.GetType().Name} on {platform.GetType().Name}: {status}");
            return status;
        }
    }
}