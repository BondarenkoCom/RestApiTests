using NUnit.Framework;
using System;
using System.Text.Json;
using System.Threading.Tasks;
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
            var request = _apiWebDriver.RunDriverClient(driverValues.url, 
                driverValues.urlNasaApiTypePlanetary, 
                driverValues.urlPartApiKey);
            var sortData = JsonSerializer.Deserialize<ResponseModel>(request.Result);
            
            Assert.Multiple(() =>
            {
                Assert.That(sortData.date, Is.Not.Null);
                Assert.That(sortData.date, Is.Not.Empty);

                Assert.That(sortData.explanation, Is.Not.Empty);
                Assert.That(sortData.explanation, Is.Not.Null);

                Assert.That(sortData.media_type, Is.Not.Empty);
                Assert.That(sortData.media_type, Is.Not.Null);
                Assert.That(sortData.media_type, Does.Match(_jsonReader.GetData().media_type));

                Assert.That(sortData.title, Is.Not.Empty);
                Assert.That(sortData.title, Is.Not.Null);

                Assert.That(sortData.hdurl, Is.Not.Empty);
                Assert.That(sortData.hdurl, Is.Not.Null);
            });
        }

        [Test]
        [Parallelizable]
        public void Positive_Test_GET_Mars_Weather()
        {
            var request = _apiWebDriver.RunDriverClient(driverValues.url,
                driverValues.urlMarsWeatherWithApuKey);
            var sortData = JsonSerializer.Deserialize<ResponseModel>(request.Result);

            Assert.Multiple(() =>
            { 
                Assert.That(sortData.validity_checks.sols_checked.ToString()[0], Is.Not.Empty);
                Assert.That(sortData.validity_checks.sols_checked.ToString()[0], Is.Not.Null);

                Assert.That(sortData.validity_checks.sol_hours_required.ToString()[0], Is.Not.Empty);
                Assert.That(sortData.validity_checks.sol_hours_required.ToString()[0], Is.Not.Null);
                
                Console.WriteLine(sortData.validity_checks.sols_checked);
            });

        }
    }
}
