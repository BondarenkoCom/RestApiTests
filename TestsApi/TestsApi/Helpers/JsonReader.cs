using System;
using System.IO;
using Newtonsoft.Json;
using TestsApi.Models;

namespace TestsApi.Helpers
{
    public class JsonReader
    {
        public JsonModelValueForComresion? GetData()
        {
            var getPath = Path.Combine(
                AppContext.BaseDirectory,
                "JsonFiles",
                "valuesForComparison.json");

            string json = File.ReadAllText(getPath);
            return JsonConvert.DeserializeObject<JsonModelValueForComresion>(json);
        }
    }
}
