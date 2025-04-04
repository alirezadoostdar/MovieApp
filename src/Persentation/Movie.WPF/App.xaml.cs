﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.Application.Services;
using Movie.Infrastructure;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Movie.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //string dbType = "sqllite";

                    //if( dbType == "sqllite")
                    //{
                    string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Movie.db");
                    string connectionString = $"Data Source={dbPath}";
                    services.AddDbContext<MovieDbContext>(options =>
                        options.UseSqlite(connectionString));
                    //}
                    services.RegisterInfrastructureServices();
                    services.AddScoped<DirectorService>();
                    services.AddScoped<GenreService>();
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            base.OnStartup(e);


        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }

}
