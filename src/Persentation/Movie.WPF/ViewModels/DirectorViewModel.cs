using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Services;
using Movie.Application.Dtos;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Movie.WPF.Commands;
using Microsoft.VisualBasic.FileIO;
using System.Windows;
using System.ComponentModel;
using Movie.Domain.Entities;
using System.IO;

namespace Movie.WPF.ViewModels;

public class DirectorViewModel : BaseViewModel, IDataErrorInfo
{

    public ObservableCollection<DirectorDto> Items { get; set; }
    public readonly DirectorService directorService;

    public RelayCommand AddCommand => new RelayCommand(execute => AddDirector());

    public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteDirector(), canExecute => !IsUsedDirector() && Id > 0);
    public RelayCommand UpdateCommand 
    {
        get
        {
            return new RelayCommand(exc => UpdateDirector(), canExe => Id > 0);
        }
    }

    private void UpdateDirector()
    {
        try
        {
            directorService.Update(new DirectorDto(Id, Name, Bio));
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }

    public DirectorViewModel()
    {
        directorService = App.AppHost.Services.GetRequiredService<DirectorService>();

        LoadData();
    }
    public void LoadData()
    {
        if (directors is null)
            directors = new ObservableCollection<DirectorDto>();
         var list = directorService.GetAll();
        Directors.Clear();
        foreach (var item in list) 
        {
            Directors.Add(item);
        }
    }

    private ObservableCollection<DirectorDto> directors;

    public ObservableCollection<DirectorDto> Directors
    {
        get { return directors; }
        set 
        {
            directors = value; 
            NotifyPropertyChanged(nameof(Items));
        }
    }

    private DirectorDto director;

    public DirectorDto Director
    {
        get { return director; }
        set
        {
            director = value;
            if (director != null)
            {
                Id = value.Id;
                Name = value.Title;
                Bio = value.Bio;
            }
            NotifyPropertyChanged(nameof(Director));
        }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; NotifyPropertyChanged(); }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; NotifyPropertyChanged(); }
    }

    private string bio;

    public string Bio
    {
        get { return bio; }
        set { bio = value; NotifyPropertyChanged(); }
    }

    public string Error => null;

    public string this[string columnName]
    {
        get
        {
            switch (columnName)
            {
                case nameof(Name):
                    {
                        if (string.IsNullOrEmpty(Name))
                            return "Please insert title";
                        break;
                    }
                case nameof(Bio):
                    {
                        if (string.IsNullOrEmpty(Bio))
                            return "Please insert biography";
                        break;
                    }
            }
            return null;
        }
    }
    private void DeleteDirector()
    {
        try
        {
            if (MessageBox.Show($"Are you sure to delete this item {director.Id}?", "Delete Alarm",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                directorService.Delete(director.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK
                , MessageBoxImage.Error);
        }
    }

    private bool IsUsedDirector()
    {
        if (Id == null)
            return false;
        else
            return directorService.IsUsed(Id);
    }

    private void AddDirector()
    {
        try
        {
            directorService.Add(new DirectorDto(0, Name, Bio));
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }

}
