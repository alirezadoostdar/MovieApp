using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Dtos;
using Movie.Application.Services;
using Movie.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


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
                Title = value.Title;
            }
            NotifyPropertyChanged(nameof(genre));
        }
    }

    #region Commands
    public RelayCommand AddCommand => new RelayCommand(exe => Add());

    public RelayCommand UpdateCommand => new RelayCommand(exc => Update(),canExc => Id > 0 );

    public RelayCommand DeleteCommand => new RelayCommand(exe => Delete(), canExe => Id > 0);

    private void Delete()
    {
        try
        {
            if(MessageBox.Show($"are you sure to delete this itme by id {Id}", "danger" ,MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
              genreService.Delete(id);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK
    , MessageBoxImage.Error);
        }
    }

    private bool IsUsed()
    {
        if (Id == null)
            return false;
        return genreService.IsUsedBefore(id);
    }

    private void Update()
    {
        try
        {
            genreService.Update(new GenreDto { Id = Id, Title = Title });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK
            , MessageBoxImage.Error);
        }
    }
    #endregion

  
    public void Add()
    {
        try
        {
            genreService.Add(new GenreDto { Id = 0, Title = Title });
            MessageBox.Show($"new genre {Title} added successfully", "success", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Id = 0;
            Title = string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK
             , MessageBoxImage.Error);
        }
    }
}
