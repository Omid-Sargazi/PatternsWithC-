namespace CompositePattern.Adapter
{
    public class Mp3Player : IMediaPlayer
    {
        public void Play(string fileType, string fileName)
        {
            if(fileType.ToLower() == "mp3")
            {
                Console.WriteLine($"Playing MP3 file: {fileName}");
            }else
            {
                Console.WriteLine($"Mp3Player: Cannot play {fileType} files.");
            }
        }
    }
}