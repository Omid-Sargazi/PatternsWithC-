namespace BehavioralPattern02.VisitorPattern
{
    public interface IFileSystemComponent
    {
        void Accept(IFileSystemVisitor fileSystemVisitor);
    }

    public interface IFileSystemVisitor
    {
        void Visit(File file);
        void Visit(Folder folder);
    }

    public class File : IFileSystemComponent
    {
        public string Name {get; set;}
        public double Size {get; set;}
        public File(string name, double size)=>(Name,Size)=(name, size);

        public void Accept(IFileSystemVisitor fileSystemVisitor)
        {
            fileSystemVisitor.Visit(this);
        }
    }

    public class Folder : IFileSystemComponent
    {
        private List<IFileSystemComponent> _children = new();
        public string Name {get; set;}
        public void Add(IFileSystemComponent file)
        {
            _children.Add(file);
        }
        public void Accept(IFileSystemVisitor fileSystemVisitor)
        {
            fileSystemVisitor.Visit(this);
            foreach(var child in _children)
            {
                child.Accept(fileSystemVisitor);
            }
        }
    }

    public class SizeCalculatorVisitor : IFileSystemVisitor
    {
        public double TotalSize {get; set;}
        public void Visit(File file)
        {
            TotalSize += file.Size;
        }

        public void Visit(Folder folder)
        {
            throw new NotImplementedException();
        }
    }
}