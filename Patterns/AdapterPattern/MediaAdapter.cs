namespace Patterns.AdapterPattern
{
    public class MediaAdapter : IMediaPlayer
    {
        private AdvancedMediaLibrary _advancedMediaLibrary;
        public MediaAdapter()
        {
            _advancedMediaLibrary = new AdvancedMediaLibrary();
        }
        public void Play(string audioType, string fileName)
        {
            if(audioType  == "mp3")
            {
                _advancedMediaLibrary.PlayMp4(fileName);
            }else if(audioType == "wav")
            {
                _advancedMediaLibrary.PlayWav(fileName);
            }
            else{
                Console.WriteLine($"MediaAdapter: Cannot play {audioType} files.");
            }
        }
    }
}