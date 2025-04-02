
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Repositories;

namespace Movie.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();

        return services;
    }
}
