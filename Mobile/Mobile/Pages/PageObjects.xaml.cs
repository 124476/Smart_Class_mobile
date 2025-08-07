namespace Mobile.Pages;

using System.Windows.Input;
using Object = Mobile.Models.Object;

public partial class PageObjects : ContentPage
{
    public ICommand ItemTappedCommand { get; }

    List<Object> objects;

    public PageObjects()
    {
        InitializeComponent();

        objects = new List<Object>()
            {
                new Object()
                {
                    Id = 1,
                    Name = "Русский язык",
                },
                new Object()
                {
                    Id = 2,
                    Name = "Математика",
                },
                new Object()
                {
                    Id = 3,
                    Name = "Физика",
                },
            };

        ItemTappedCommand = new Command<Object>(OnObjectSelected);
        ListObjects.ItemsSource = objects;
        BindingContext = this;
    }

    private async void OnObjectSelected(Object selectedObject)
    {
        if (selectedObject == null) return;

        // Переход на новую страницу
        await Navigation.PushAsync(new PageTopics(selectedObject));
    }
}