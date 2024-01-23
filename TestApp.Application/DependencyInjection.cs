using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Application.Coins.Commands.CreateCoin.Factory;
using TestApp.Application.Common.Behaviors;
using TestApp.Application.Drinks.Commands.CreateDrink.Factory;
using TestApp.Application.Interfaces;
using TestApp.Application.Services;

namespace TestApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IDrinkFactory, DrinkFactory>();
            services.AddScoped<ICoinFactory, CoinFactory>();
            services.AddScoped<IBuyDrinkService, BuyDrinkService>();
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
