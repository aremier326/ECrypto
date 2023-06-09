﻿using ECrypto.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECrypto.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
            .AddTransient<IApiService, ApiService>()
            .AddTransient<IThemeService, ThemeService>();

    }
}
