using ServiceLayer;
using ServiceLayer.DTOs;
using ServiceLayer.Models;
using ServiceLayer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ElectronicTextbook.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page, INotifyPropertyChanged
    {
        public static readonly TestService _testService = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<QuestionDTO> _testQuestions;
        public ObservableCollection<QuestionDTO> TestQuestions
        {
            get => _testQuestions;
            set
            {
                if (_testQuestions != value)
                {
                    _testQuestions = value;
                    OnPropertyChanged();
                }
            }
        }
        public string _userLoginText { get; set; } = "Пользователь: ";
        public string UserLoginText
        {
            get => _userLoginText;
            set
            {
                if (_userLoginText != value)
                {
                    _userLoginText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _testName { get; set; }
        public string TestName
        {
            get => _testName;
            set
            {
                if (_testName != value)
                {
                    _testName = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public Lection Lection { get; set; }
        public Test Test { get; set; }

        public TestPage(Lection lection)
        {
            InitializeComponent();
            DataContext = this;
            UserLoginText = $"Пользователь: {CurrentUser.UserLogin}";
            Lection = lection;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadTestAsync();
        }

        private async Task LoadTestAsync()
        {
            Test = await _testService.GetTestByLectionIdAsync(Lection.LectionId);
            TestName = await _testService.GetTestNameAsync(Test);
            TestQuestions = new ObservableCollection<QuestionDTO>();
            foreach (Question question in Test.Questions)
            {
                QuestionDTO questionDTO = new QuestionDTO()
                {
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText,
                    Answers = question.Answers,
                    TestId = question.TestId
                };
                TestQuestions.Add(questionDTO);
            }
        }

        private void ToLectionButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new LectionPage(Lection));
        }

        private void ToNavigatorButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new LectionsNavigatorPage());
        }

        private void FinishTestButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new TestResultPage(Test));
        }
    }
}
