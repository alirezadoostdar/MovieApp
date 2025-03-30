using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.WPF.ViewModels;

public class DirectorViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
    public readonly DirectorService directorService;

    public DirectorViewModel()
    {
        directorService = App.AppHost.Services.GetRequiredService<DirectorService>();
        directorService.Add(new Movie.Application.Dtos.DirectorDto(0, "sorosh sehat", "coment"));
        var list = directorService.GetAll();
    }
}
