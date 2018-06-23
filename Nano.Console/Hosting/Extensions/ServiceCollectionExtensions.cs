﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nano.Config.Extensions;

namespace Nano.Console.Hosting.Extensions
{
    /// <summary>
    /// Service Collection Extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="ConsoleOptions"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddConsole(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            services
                .AddConfigOptions<ConsoleOptions>(configuration, ConsoleOptions.SectionName, out _);

            return services;
        }

        /// <summary>
        /// Clone the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The cloned <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection Clone(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            IServiceCollection clonedServices = new ServiceCollection();

            foreach (var service in services)
            {
                clonedServices.Add(service);
            }

            return clonedServices;
        }
    }
}