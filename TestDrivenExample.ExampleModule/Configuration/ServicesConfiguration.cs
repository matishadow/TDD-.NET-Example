using Microsoft.Extensions.DependencyInjection;
using TestDrivenExample.ExampleModule.Internal;
using TestDrivenExample.ExampleModule.PublicClasses;

namespace TestDrivenExample.ExampleModule.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddExampleModule(this IServiceCollection services)
        {
            services.AddScoped<ITemperatureConverter, TemperatureConverter>();
            services.AddScoped<IConversionRates, ConversionRates>();
            services.AddScoped<IDoubleAdder, DoubleAdder>();
            services.AddScoped<ITemperatureArgumentValidator, TemperatureArgumentValidator>();
        }
    }
}