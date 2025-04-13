namespace CompositePattern.Adapter
{
    public class MediaPlayer : IMediaPlayer
    {
        private IMediaPlayer _mediaPlayer;
       
        public void Play(string fileType, string fileName)
        {
            if(fileType.ToLower()=="mp3")
            {
                _mediaPlayer = new Mp3Player();
            }else{
                _mediaPlayer = new AdapterMediaPlayer();
            }
            _mediaPlayer.Play(fileType, fileName);
        }
    }
}