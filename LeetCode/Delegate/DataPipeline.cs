namespace LeetCode.Delegate
{
    public abstract class DataPipeline
    {
        public abstract void Process(string data, Func<string, string> transform);
    }

    public class JsonPipeline : DataPipeline
    {
        public override void Process(string data, Func<string, string> transform)
        {
            Console.WriteLine("🔽 Raw: " + data);
            var result = transform(data);
            Console.WriteLine("🔼 Transformed: " + result);
        }
    }

    public class ClientPipeline
    {
        public static void Run()
        {
            JsonPipeline pipeline = new JsonPipeline();
            pipeline.Process("{name:`Omid`}",s=>s.Replace("`","\""));
            pipeline.Process("data", s => s.ToUpper());
        }
    }
}