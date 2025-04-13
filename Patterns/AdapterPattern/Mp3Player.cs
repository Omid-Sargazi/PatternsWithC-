namespace Patterns.AdapterPattern
{
    public class Mp3Player : IMediaPlayer
    {
        public void Play(string audioType, string fileName)
        {
            if(audioType == "mp3")
            {
                Console.WriteLine($"Playing MP3 file: {fileName}");
            }
            else
            {
                Console.WriteLine($"Mp3Player: Cannot play {fileName} files.");
            }
        }
    }
}