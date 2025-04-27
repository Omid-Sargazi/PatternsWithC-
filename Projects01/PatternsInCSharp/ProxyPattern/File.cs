namespace PatternsInCSharp.ProxyPattern
{
    public class File
    {
        public string FileName {get;}
        public long FileSizeInBytes {get;}
        public byte[] FileData {get;}

        public File(string fileName, long fileSizeInBytes, byte[] fileData)
        {
            FileName = fileName;
            FileSizeInBytes = fileSizeInBytes;
            FileData = fileData;
        }

        public class FileDownloader
        {
            private File _file;
            private readonly string _fileId;


            public FileDownloader(string fileId)
            {
                _fileId = fileId;
                _file = LoadFileFromServer();
            }

            private File LoadFileFromServer()
            {
                Console.WriteLine($"Downloading file {fileId} from server...");
                Thread.Sleep(2500); // ۲.۵ ثانیه تاخیر
                return new File("document.pdf", 1048576, new byte[1048576]); // ۱ مگابایت داده
            }



            public string GetFileName()
            {
                return _file.FileName;
            }

            public long GetFileSize()
            {
                return _file.FileSizeInBytes;
            }

            public byte[] DownloadFile()
            {
                return _file.FileData;
            }
        }
    }
}