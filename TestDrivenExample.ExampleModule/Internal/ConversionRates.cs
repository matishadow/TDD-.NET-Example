namespace TestDrivenExample.ExampleModule.Internal
{
    internal class ConversionRates : IConversionRates
    {
        public double GetCelsiusToKelvinConversionRate()
        {
            return 273.15;
        }
    }
}