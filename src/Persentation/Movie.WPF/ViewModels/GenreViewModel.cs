using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Dtos;
using Movie.Application.Services;
using Movie.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.WPF.ViewModels;

public class GenreViewModel : BaseViewModel
{
    public ObservableCollection<GenreDto> genres { get; set; }
    private readonly GenreService genreService;
    public GenreViewModel()
    {
        genreService = App.AppHost.Services.GetRequiredService<GenreService>();
        genres = new ObservableCollection<GenreDto>(genreService.GetAll());
    }
    private int id;

    public int Id
    {
        get { return id; }
        set 
        { 
            id = value; 
            NotifyPropertyChanged(nameof(id));
        }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set 
        {
            title = value; 
            NotifyPropertyChanged(nameof(title));
        }
    }

    private GenreDto genre;

    public GenreDto Genre
    {
        get { return genre; }
        set 
        { 
            genre = value;
            if (genre != null)
            {
                Id = value.Id;
                title = value.Title;
            }
            NotifyPropertyChanged(nameof(genre));
        }
    }

    #region Commands
    public RelayCommand AddCommand => new RelayCommand(exe => Add());

    public RelayCommand UpdateCommand => new RelayCommand(exc => Update() );

    private void Update()
    {
        throw new NotImplementedException();
    }
    #endregion

    public Func<GenreDto, bool> IsDuplicate;
    public bool salaryCalculate(Func<GenreDto,bool> func)
    {
        return func(new GenreDto() { Id = 10, Title = "dsss" });
    }
  
    public void Add()
    {
        genreService.Add(new GenreDto { Id = id, Title = Title });
    }
}
