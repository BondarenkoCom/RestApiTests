using NUnit.Framework;
using System;
using System.Linq;
using System.Text.Json;
using TestsApi.Helpers;
using TestsApi.Models;
using TestsApi.Values;
using TestsApi.WebDriver;

namespace TestsApi.ApiTests
{
    public class PositiveTests
    {
        readonly ApiWebDriver _apiWebDriver = new ApiWebDriver();
        readonly JsonReader _jsonReader = new JsonReader();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Description("https://api.nasa.gov/")]
        [Parallelizable]
        public void Positive_Test_GET_Planetary()
        {
            var request = _apiWebDriver.RunDriverClient(
                driverValues.url,
                driverValues.urlNasaApiTypePlanetary,
                driverValues.urlPartApiKey);

            var sortData = JsonSerializer.Deserialize<ResponseModel>(request.Result);
            var expectedData = _jsonReader.GetData();

            Assert.That(sortData, Is.Not.Null);
            Assert.That(expectedData, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(sortData!.date, Is.Not.Null.And.Not.Empty);
                Assert.That(sortData.explanation, Is.Not.Null.And.Not.Empty);
                Assert.That(sortData.media_type, Is.Not.Null.And.Not.Empty);
                Assert.That(sortData.media_type, Is.EqualTo(expectedData!.media_type));
                Assert.That(sortData.title, Is.Not.Null.And.Not.Empty);
                Assert.That(sortData.hdurl, Is.Not.Null.And.Not.Empty);
            });
        }

        [Test]
        [Parallelizable]
        public void Positive_Test_GET_Mars_Weather()
        {
            var request = _apiWebDriver.RunDriverClient(
                driverValues.url,
                driverValues.urlMarsWeatherWithApuKey);

            using var document = JsonDocument.Parse(request.Result);
            var validityChecks = document.RootElement.GetProperty("validity_checks");
            var solsChecked = validityChecks.GetProperty("sols_checked");
            var solHoursRequired = validityChecks.GetProperty("sol_hours_required");

            Assert.Multiple(() =>
            {
                Assert.That(solsChecked.ValueKind, Is.EqualTo(JsonValueKind.Array));
                Assert.That(solsChecked.EnumerateArray().Any(), Is.True);

                Assert.That(solHoursRequired.ValueKind, Is.EqualTo(JsonValueKind.Number));
                Assert.That(solHoursRequired.GetInt32(), Is.GreaterThan(0));

                Console.WriteLine(solsChecked.ToString());
            });
        }
    }
}
