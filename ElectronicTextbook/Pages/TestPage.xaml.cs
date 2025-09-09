using ServiceLayer.Models;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicTextbook.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public static readonly TestService _testService = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Lection> _testQuestions;
        public ObservableCollection<Lection> TestQuestions
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

        public Lection _selectedLection { get; set; }
        public Lection SelectedLection
        {
            get => _selectedLection;
            set
            {
                if (_selectedLection != value)
                {
                    _selectedLection = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public TestPage(int lectionId)
        {
            InitializeComponent();
            LoadTestAsync(lectionId);
        }

        private async Task LoadTestAsync(int lectionId)
        {
            Test test = await _testService.GetTestByIdAsync(lectionId);
            TestName = 
        }
    }
}
