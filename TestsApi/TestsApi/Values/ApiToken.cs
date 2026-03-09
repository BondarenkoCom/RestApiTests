using System;

namespace TestsApi.Values
{
    public static class ApiToken
    {
        public static string NASAToken =>
            Environment.GetEnvironmentVariable("NASA_API_KEY") ?? "DEMO_KEY";
    }
}
