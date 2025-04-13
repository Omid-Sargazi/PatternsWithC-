namespace CompositePattern.Adapter
{
    public class AdapterMediaPlayer : IMediaPlayer
    {
        private AdvancedMediaLibrary _player;
        public AdapterMediaPlayer(AdvancedMediaLibrary player)
        {
            _player = player;
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