using felipehilst_d7_avaliacao.Services;
using System.Windows;
using System.Windows.Controls;

namespace felipehilst_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ILoginService? loginService;
        public string Email = string.Empty;
        public string Password = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox password)
                Password = password.Password;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
                Email = textBox.Text;
        }

        private void Acessar_Click(object sender, RoutedEventArgs e)
        {
            if (loginService == null) return;
            if (loginService.IsValidUser(Email, Password))
            {
                AprovadoPopup.IsOpen = true;
            }
            else
            {
                ReprovadoPopup.IsOpen = true;
            }
        }
    }
}
