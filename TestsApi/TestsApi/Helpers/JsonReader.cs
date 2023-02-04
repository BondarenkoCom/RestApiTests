using System.IO;
using Newtonsoft.Json;
using TestsApi.Models;

namespace TestsApi.Helpers
{
    public class JsonReader
    {
        public JsonModelValueForComresion? GetData()
        {
            var getPath = @"C:\Users\Honor\source\repos\RestApiTest\TestsApi\TestsApi\JsonFiles\valuesForComparison.json";

            string json = File.ReadAllText(getPath);
            JsonModelValueForComresion values = JsonConvert.DeserializeObject<JsonModelValueForComresion>(json);
            return values;
        }

    }
}
