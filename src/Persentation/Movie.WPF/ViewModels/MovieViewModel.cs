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
using System.Windows.Controls;

namespace Movie.WPF.ViewModels;

public class MovieViewModel : BaseViewModel
{
    private readonly MovieService movieService;

    public MovieViewModel()
    {
        this.movieService = App.AppHost.Services.GetRequiredService<MovieService>();
        Movies = new ObservableCollection<MovieDto>(movieService.GetAll());
    }
    #region Fields
    private ObservableCollection<MovieDto> movies;

    public ObservableCollection<MovieDto> Movies
    {
        get { return movies; }
        set
        {
            movies = value;
            NotifyPropertyChanged(nameof(Movies));
        }
    }

    private MovieDto selectedIndex;

    public MovieDto SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = value; NotifyPropertyChanged(); }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; NotifyPropertyChanged(); }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; NotifyPropertyChanged(); }
    }

    private decimal imdb;

    public decimal Imdb
    {
        get { return imdb; }
        set { imdb = value; NotifyPropertyChanged(); }
    }

    private int directorId;

    public int DirectorId
    {
        get { return directorId; }
        set { directorId = value; NotifyPropertyChanged(); }
    }

    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; NotifyPropertyChanged(); }
    }

    private string year;

    public string Year
    {
        get { return year; }
        set { year = value; NotifyPropertyChanged(); }
    }

    private string poster;

    public string Poster
    {
        get { return poster; }
        set { poster = value; NotifyPropertyChanged(); }
    }

    private string cast;
            
    public string Cast
    {
        get { return cast; }
        set { cast = value; NotifyPropertyChanged(); }
    }


    #endregion

    #region Command
    public RelayCommand AddCommand => new RelayCommand(execute => Add(), canExecute => IsValid());

    private void Add()
    {
        try
        {
            movieService.Add(SelectedIndex);
        }
        catch (Exception)
        {

            throw;
        }
    }

    private bool IsValid()
    {
        throw new NotImplementedException();
    }
    #endregion
}
