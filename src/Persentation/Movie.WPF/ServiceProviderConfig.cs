using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Services;
using Movie.Domain.Interfaces;
using Movie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.WPF;

public static class ServiceProviderConfig
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddDbContext<MovieDbContext>(options =>
        options.UseSqlite("Data Source = MovieDB.db"));

        //services.AddDbContext<MovieDbContext>(options =>
        //    options.UseSqlServer(connectionString));
        //services.RegisterInfrastructureServices();

        // ثبت ریپوزیتوری‌ها و سرویس
        //services.AddScoped<IMovieRepository, MovieRepository>();
        //services.AddScoped<IDirectorRepository, dire>();
        //services.AddScoped<IGenreRepository, GenreRepository>();
        //services.AddScoped<DirectorService>();
        //services.AddScoped<MovieViewModel>();

        return services.BuildServiceProvider();
    }
}
