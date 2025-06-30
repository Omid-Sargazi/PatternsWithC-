namespace DesignPattern.ProxyPattern
{
    public class VideoFile
    {
        public string FileName { get; set; }
        public int SizeInMB { get; set; }
        public byte[] Data { get; set; }

        public VideoFile(string fileName, int sizeInMB)
        {
            FileName = fileName;
            SizeInMB = sizeInMB;
            Console.WriteLine($"⏳ Downloading {fileName} ({sizeInMB}MB)...");
        }

        private void DownloadFromServer()
        {
            for (int i = 0; i < -100; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine($"Progress{i}");
            }
            Data = new byte[SizeInMB * 1024 * 1024]; // تقریبی
            Console.WriteLine($"✅ {FileName} downloaded successfully!");
        }

        public void Play()
        {
            if (Data != null)
            {
                Console.WriteLine($"🎬 Playing {FileName}...");
            }
            else
            {
                Console.WriteLine("❌ File not available!");
            }
        }
    }

    public class VideoPlayer
    {
        public void PalyVideo(string fileName, int SizeInMB)
        {
            VideoFile video1 = new VideoFile(fileName, SizeInMB);
            video1.Play();

            Console.WriteLine("\n--- User wants to replay ---");
             
              VideoFile video2 = new VideoFile(fileName, SizeInMB);
              video2.Play();
        }
    }
}