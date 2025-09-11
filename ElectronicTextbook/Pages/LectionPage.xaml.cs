using ServiceLayer;
using ServiceLayer.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ElectronicTextbook.Pages
{
    /// <summary>
    /// Логика взаимодействия для LectionPage.xaml
    /// </summary>
    public partial class LectionPage : Page
    {
        public event PropertyChangedEventHandler? PropertyChanged;
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
        private BitmapImage _currentImage;
        public BitmapImage CurrentImage
        {
            get => _currentImage;
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public LectionPage(Lection selectedLection)
        {
            InitializeComponent();
            DataContext = this;
            SelectedLection = selectedLection;
            UserLoginText = $"Пользователь: {CurrentUser.UserLogin}";
            SetImage(selectedLection.LectionId.ToString());
        }

        public void SetImage(string imageName)
        {
            CurrentImage = new BitmapImage(new Uri($"pack://application:,,,/Images/{imageName}.png"));
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new LectionsNavigatorPage());
        }

        private void ToTestButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new TestPage(SelectedLection));
        }
    }
}
