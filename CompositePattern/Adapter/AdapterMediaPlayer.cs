namespace CompositePattern.Adapter
{
    public class AdapterMediaPlayer : IMediaPlayer
    {
        private AdvancedMediaLibrary _player;
        public AdapterMediaPlayer()
        {
            _player = new AdvancedMediaLibrary();
        }
        public void Play(string fileType, string fileName)
        {
            if(fileType == "MP4")
            {
                _player.PlayMp4(fileName);
            }
            if(fileType == "WAV")
            {
                _player.PlayWav(fileName);
            }
            else
            {
                Console.WriteLine($"AdapterMediaPlayer: Cannot play {fileType} files.");
            }
        }
    }
}