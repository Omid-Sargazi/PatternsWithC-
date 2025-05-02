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
        public IUIRenderer CreateUIRenderer()
        {
            return new WebUIRenderer();
        }

        public IDataStorage CreateDataStorage()
        {
            return new WebDataStorage();
        }
    }

    public class MobileCMSFactory : ICMSFactory
    {
        public IUIRenderer CreateUIRenderer()
        {
            return new MobileUIRenderer();
        }

        public IDataStorage CreateDataStorage()
        {
            return new MobileDataStorage();
        }
    }

    public class DesctopCMSFactory : ICMSFactory
    {
        public IUIRenderer CreateUIRenderer()
        {
            return new DesctopUIRenderer();
        }

        public IDataStorage CreateDataStorage()
        {
            return new DesctopDataStorage();
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