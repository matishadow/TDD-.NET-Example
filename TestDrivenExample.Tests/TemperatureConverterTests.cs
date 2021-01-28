using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestDrivenExample.ExampleModule.Configuration;
using TestDrivenExample.ExampleModule.PublicClasses;

namespace TestDrivenExample.Tests
{
    public class TemperatureConverterTests
    {
        private ITemperatureConverter _temperatureConverter;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddExampleModule();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _temperatureConverter = serviceProvider.GetService<ITemperatureConverter>();
        }

        [TestCase(10, 283.15)]
        [TestCase(20, 293.15)]
        [TestCase(100, 373.15)]
        [TestCase(500, 773.15)]
        [TestCase(5000, 5273.15)]
        public void Should_Convert_Degrees_From_Celsius_To_Kelvin(double celsiusDegrees, double expectedResult)
        {
            var valueInKelvins = _temperatureConverter.ConvertFromCelsiusToKelvin(celsiusDegrees);

            valueInKelvins.Should().Be(expectedResult);
        }

        [TestCase(-273.16)]
        [TestCase(-373.15)]
        [TestCase(-1000)]
        public void Should_Throw_Argument_Exception_If_Input_Below_Absolute_Zero(double celsiusDegrees)
        {
            Action convertAction = () => _temperatureConverter.ConvertFromCelsiusToKelvin(celsiusDegrees);

            convertAction.Should().Throw<ArgumentException>();
        }
    }
}