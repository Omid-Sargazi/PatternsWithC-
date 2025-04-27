using System.Security.Cryptography;

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
    }

        public class FileDownloader : IFileDownloader
        {
            private File _file;
            private readonly string _fileId;


            public FileDownloader(string fileId)
            {
                _fileId = fileId;
                
            }

            private File LoadFileFromServer()
            {
                Console.WriteLine($"Downloading file {_fileId} from server...");
                Thread.Sleep(2500); // ۲.۵ ثانیه تاخیر
                return new File("document.pdf", 1048576, new byte[1048576]); // ۱ مگابایت داده
            }



            public string GetFileName()
            {
                _file ??= LoadFileFromServer();
                return _file.FileName;
            }

            public long GetFileSize()
            {
                _file ??= LoadFileFromServer();
                return _file.FileSizeInBytes;
            }

            public byte[] DownloadFile()
            {
                _file ??= LoadFileFromServer();
                return _file.FileData;
            }
        }
    
        public interface IFileDownloader
        {
            string GetFileName();
            long GetFileSize();
            byte[] DownloadFile();
        }

    public class FileDownloaderProxy : IFileDownloader
    {
        private File _file;
        private readonly string _fileId;
        private FileDownloader _fileDownloader;

        public  FileDownloaderProxy(string fileId)
        {
            _fileId = fileId;
            _file = new File("document.pdf", 105874, null); // ۱ مگابایت داده
        }
        public byte[] DownloadFile()
        {
            _fileDownloader ??= new FileDownloader(_fileId);
            return _fileDownloader.DownloadFile();
        }

        public string GetFileName()
        {
            return _file.FileName;
        }

        public long GetFileSize()
        {
            return _file.FileSizeInBytes;
        }
    }

}