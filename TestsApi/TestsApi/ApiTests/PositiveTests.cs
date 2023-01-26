using NUnit.Framework;
using System;
using TestsApi.Values;
using TestsApi.WebDriver;

namespace TestsApi.ApiTests
{
    public class PositiveTests
    {
        ApiWebDriver _apiWebDriver = new ApiWebDriver();


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Just_client()
        {
            var request = _apiWebDriver.RunDriverClient(driverValues.url);
            Assert.Multiple(() =>
            {
                Console.WriteLine(request.Result);
            });

            Assert.Pass();
        }
    }
}
