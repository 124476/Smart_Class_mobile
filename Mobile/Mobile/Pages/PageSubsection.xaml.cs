using Mobile.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mobile.Pages;

public partial class PageSubsection : ContentPage, INotifyPropertyChanged
{
    public Topic Topic { get; set; }
    private List<Subsection> subsections;
    private Random random = new Random();

    // Текущий вопрос
    private Subsection currentQuestion;
    public Subsection CurrentQuestion
    {
        get => currentQuestion;
        set
        {
            currentQuestion = value;
            OnPropertyChanged();
        }
    }

    // Ответ пользователя
    private string userAnswer;
    public string UserAnswer
    {
        get => userAnswer;
        set
        {
            userAnswer = value;
            OnPropertyChanged();
        }
    }

    // Проверен ли ответ
    private bool isAnswerChecked;
    public bool IsAnswerChecked
    {
        get => isAnswerChecked;
        set
        {
            isAnswerChecked = value;
            OnPropertyChanged();
        }
    }

    // Сообщение результата
    private string resultMessage;
    public string ResultMessage
    {
        get => resultMessage;
        set
        {
            resultMessage = value;
            OnPropertyChanged();
        }
    }

    // Цвет результата
    private Color resultColor;
    public Color ResultColor
    {
        get => resultColor;
        set
        {
            resultColor = value;
            OnPropertyChanged();
        }
    }

    public ICommand CheckAnswerCommand { get; }
    public ICommand NextQuestionCommand { get; }

    public PageSubsection(Topic topic)
    {
        InitializeComponent();
        Topic = topic;

        // Инициализация вопросов
        subsections = new List<Subsection>()
        {
            new Subsection() { Id = 1, Topic_Id = 1, Name = "Вопрос 1", Description = "Ответ 1" },
            new Subsection() { Id = 2, Topic_Id = 1, Name = "Вопрос 2", Description = "Ответ 2" },
            new Subsection() { Id = 3, Topic_Id = 1, Name = "Вопрос 3", Description = "Ответ 3" },
        };

        // Команды
        CheckAnswerCommand = new Command(CheckAnswer);
        NextQuestionCommand = new Command(NextQuestion);

        // Выбор первого случайного вопроса
        NextQuestion();

        BindingContext = this;
    }

    private void CheckAnswer()
    {
        if (string.IsNullOrWhiteSpace(UserAnswer))
        {
            DisplayAlert("Ошибка", "Введите ваш ответ", "OK");
            return;
        }

        IsAnswerChecked = true;

        bool isCorrect = UserAnswer.Trim().Equals(
            CurrentQuestion.Description.Trim());

        ResultMessage = isCorrect ? "Правильно! ✅" : "Неправильно! ❌";
        ResultColor = isCorrect ? Color.FromArgb("#4CAF50") : Color.FromArgb("#F44336");
    }

    private void NextQuestion()
    {
        if (subsections.Count == 0)
        {
            DisplayAlert("Поздравляем!", "Вы ответили на все вопросы!", "OK");
            return;
        }

        // Выбор случайного вопроса
        int index = random.Next(subsections.Count);
        CurrentQuestion = subsections[index];
        subsections.RemoveAt(index);

        // Сброс состояния
        UserAnswer = string.Empty;
        IsAnswerChecked = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}