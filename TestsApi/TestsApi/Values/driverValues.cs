namespace TestsApi.Values
{
    public static class driverValues
    {
        public static string url = "https://api.nasa.gov/";
        public static string urlPartApiKey = $"api_key={ApiToken.NASAToken}";
        public static string urlPartApiKeyEnd = $"&feedtype=json&ver=1.0";
        public static string urlNasaApiTypePlanetary = "/planetary/apod?";
        public static string urlMarsWeatherWithApuKey = $"/insight_weather/?api_key={ApiToken.NASAToken}&feedtype=json&ver=1.0";
    }
}
