using TestDrivenExample.ExampleModule.Internal;
using TestDrivenExample.ExampleModule.PublicClasses;

namespace TestDrivenExample.ExampleModule
{
    public class TemperatureConverter : ITemperatureConverter
    {
        private readonly IDoubleAdder _doubleAdder;
        private readonly IConversionRates _conversionRates;
        private readonly ITemperatureArgumentValidator _temperatureArgumentValidator;

        public TemperatureConverter(
            IDoubleAdder doubleAdder,
            IConversionRates conversionRates,
            ITemperatureArgumentValidator temperatureArgumentValidator)
        {
            _doubleAdder = doubleAdder;
            _conversionRates = conversionRates;
            _temperatureArgumentValidator = temperatureArgumentValidator;
        }

        public double ConvertFromCelsiusToKelvin(double celsiusDegrees)
        {
            _temperatureArgumentValidator.ValidateCelsiusToKelvinArgument(celsiusDegrees);

            var conversionRate = _conversionRates.GetCelsiusToKelvinConversionRate();

            return _doubleAdder.Add(celsiusDegrees, conversionRate);
        }
    }
}