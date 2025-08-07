namespace Mobile.Pages;

using Mobile.Models;
using System.Windows.Input;
using Object = Mobile.Models.Object;

public partial class PageTopics : ContentPage
{
    public ICommand ItemTappedCommand { get; }

    List<Topic> topics;

    public PageTopics(Object subject)
    {
        InitializeComponent();

        topics = new List<Topic>() { 
            new Topic()
            {
                Id = 1, Object_Id = 1, Name = "������� 7",
            },
            new Topic()
            {
                Id = 2, Object_Id = 1, Name = "������� 8",
            },
            new Topic()
            {
                Id = 3, Object_Id = 1, Name = "������� 9",
            },
            new Topic()
            {
                Id = 4, Object_Id = 1, Name = "������� 10",
            },


        };

        ItemTappedCommand = new Command<Topic>(OnTopicSelected);
        ListTopics.ItemsSource = topics;
        BindingContext = this;
    }

    private async void OnTopicSelected(Topic selectedTopic)
    {
        if (selectedTopic == null) return;

        // ������� �� ����� ��������
        await Navigation.PushAsync(new PageSubsection(selectedTopic));
    }
}