using System;

namespace TestDrivenExample.ExampleModule.Internal
{
    internal class TemperatureArgumentValidator : ITemperatureArgumentValidator
    {
        public void ValidateCelsiusToKelvinArgument(double celsiusDegrees)
        {
            if (celsiusDegrees < -273.15)
                throw new ArgumentException("Temperature cannot be below absolute zero.", nameof(celsiusDegrees));
        }
    }
}