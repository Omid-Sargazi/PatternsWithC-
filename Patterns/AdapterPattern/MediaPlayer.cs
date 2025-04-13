namespace Patterns.AdapterPattern
{
    public class MediaPlayer 
    {
        private IMediaPlayer _mediaPlayer;
        public void Paly(string fileTyep, string fileName)
        {
            if(fileTyep == "mp3")
            {
                _mediaPlayer = new Mp3Player();
            }else
            {
                _mediaPlayer = new MediaAdapter();
            }
            _mediaPlayer.Play(fileTyep, fileName);
        }
    }
}