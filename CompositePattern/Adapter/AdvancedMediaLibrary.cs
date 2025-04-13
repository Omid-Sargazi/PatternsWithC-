namespace CompositePattern.Adapter
{
    public class AdvancedMediaLibrary
    {
        public void PlayMp4(string fileName)
        {
            Console.WriteLine($"AdvancedMediaLibrary: Playing MP4 file: {fileName}");
        }
        public void PlayWav(string fileName)
        {
            Console.WriteLine($"AdvancedMediaLibrary: Playing WAV file: {fileName}");
        }
    }
}