using BusinessObjects.Request.Auth;
using Services;
using Services.Constant;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly IAuthService _authService = new AuthService();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new LoginPage());
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var registerRequest = new RegisterRequest() {
                    Email = EmailTextBox.Text,
                    Password = PasswordTextBox.Password,
                    UserName = UserNameTextBox.Text,
                    Role = UserRole.Client
                };
                var registerResponse = _authService.Register(registerRequest);
                if (registerResponse.IsSuccess)
                {
                    RegisterMessage.Content = "Register succesfully";
                    RegisterMessage.Foreground = Brushes.Green;
                }
                else {
                    RegisterMessage.Content = registerResponse.Message;
                    RegisterMessage.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                RegisterMessage.Content = "Invalid email address.";
                RegisterMessage.Foreground = Brushes.Red;
                RegisterButton.IsEnabled = false;
            }
            else {
                RegisterMessage.Content = string.Empty;
                RegisterButton.IsEnabled = true;
            }
        }

        private void ConfirmPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfirmPasswordTextBox.Password)) { 
                ValidatePasswords();
            }
        }
        private void ValidatePasswords()
        {
            string password = PasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordTextBox.Password;

            if (password == confirmPassword)
            {
                RegisterMessage.Content = string.Empty;
                RegisterButton.IsEnabled = true;
            }
            else
            {
                RegisterMessage.Content = "Passwords do not match.";
                RegisterMessage.Foreground = Brushes.Red;
                RegisterButton.IsEnabled = false;
            }
        }

        
    }
}
