using Indx;
using Indx.Api;

namespace IndxNugetConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var engine = new SearchEngine();

            var data = new Document[]
            {
                new (0, "The Matrix"),
                new (1, "The Matrix Reloaded"),
                new (2, "The Matrix Revolutions"),
                new (3, "The Matrix Resurrections")
            };

            engine.Insert(data);
            engine.Index();
            while (engine.Status.SystemState != SystemState.Ready) Thread.Sleep(100);
            var query = new Query("Matr", 5);

            var result = engine.Search(query);
            foreach (var r in result.SearchRecords) Console.WriteLine(r.IndexedText);
        }
    }
}