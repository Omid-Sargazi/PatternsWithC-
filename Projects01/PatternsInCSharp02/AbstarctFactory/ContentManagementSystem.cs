namespace PatternsInCSharp02.AbstarctFactory
{
    public interface IUIRenderer
    {
        void RenderUI(string context);
    }

    public interface IDataStorage
    {
        public void SaveContent(string context);
    }

    public class WebUIRenderer : IUIRenderer
    {
        private readonly Lazy<object> _apiClient;
                public void RenderUI(string context)
        {
            Console.WriteLine($"Rendering web UI with content: {context}");
        }
    }

    public class MobileUIRenderer : IUIRenderer
    {
        public void RenderUI(string context)
        {
            Console.WriteLine($"Rendering mobile UI with content: {context}");
        }
    }
    public class DesctopUIRenderer : IUIRenderer
    {
        public void RenderUI(string context)
        {
            Console.WriteLine($"Rendering desktop UI with content: {context}");
        }
    }

    public class WebDataStorage : IDataStorage
    {
        public void SaveContent(string context)
        {
            Console.WriteLine($"Saving web content: {context}");
        }
    }
    

    public class MobileDataStorage : IDataStorage
    {
        public void SaveContent(string context)
        {
            Console.WriteLine($"Saving mobile content: {context}");
        }
    }
    public class DesctopDataStorage : IDataStorage
    {
        public void SaveContent(string context)
        {
            Console.WriteLine($"Saving desktop content: {context}");
        }
    }

    public interface ICMSFactory
    {
        IUIRenderer CreateUIRenderer();
        IDataStorage CreateDataStorage();
    }

    public class WebCMSFactory : ICMSFactory
    {
        private readonly Lazy<IUIRenderer> _uiRenderer = new Lazy<IUIRenderer>(()=> new WebUIRenderer());
        private readonly Lazy<IDataStorage> _dataStorage = new Lazy<IDataStorage>(()=> new WebDataStorage());
        public IUIRenderer CreateUIRenderer()
        {
            return _uiRenderer.Value;
        }

        public IDataStorage CreateDataStorage()
        {
            return _dataStorage.Value;
        }
    }

    public class MobileCMSFactory : ICMSFactory
    {
        private readonly Lazy<IUIRenderer> _uIRenderer = new Lazy<IUIRenderer>(() => new MobileUIRenderer());
        private readonly Lazy<IDataStorage> _dataStorage = new Lazy<IDataStorage>(() => new MobileDataStorage());
        public IUIRenderer CreateUIRenderer()
        {
            return _uIRenderer.Value;
        }

        public IDataStorage CreateDataStorage()
        {
            return _dataStorage.Value;
        }
    }

    public class DesctopCMSFactory : ICMSFactory
    {
        private readonly Lazy<IUIRenderer> _uIRenderer = new Lazy<IUIRenderer>(() => new DesctopUIRenderer());
        private readonly Lazy<IDataStorage> _dataStorage = new Lazy<IDataStorage>(() => new DesctopDataStorage());
        public IUIRenderer CreateUIRenderer()
        {
            return _uIRenderer.Value;
        }

        public IDataStorage CreateDataStorage()
        {
            return _dataStorage.Value;
        }
    }

    public class ContentManager
    {
        private readonly IUIRenderer _uiRenderer;
        private readonly IDataStorage _dataStorage;

        public ContentManager(ICMSFactory factory)
        {
            _uiRenderer = factory.CreateUIRenderer();
            _dataStorage = factory.CreateDataStorage();
        }

        public void Run(string context)
        {
            _uiRenderer.RenderUI(context);
            _dataStorage.SaveContent(context);
        }
    }
}