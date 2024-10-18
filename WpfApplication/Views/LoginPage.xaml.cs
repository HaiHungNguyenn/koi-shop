using BusinessObjects.Dto;
using Services;
using Services.Constant;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApplication.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly IAuthService _authService = new AuthService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = userNameTextBox.Text;
            var password = passwordTextBox.Password;
            try
            {
                var loginResponse = _authService.Login(username, password);
                if (loginResponse.IsSuccess)
                {
                    LoginMessage.Content = "Login Successfully";
                    LoginMessage.Foreground = Brushes.Green;
                }
                else if (loginResponse.IsSuccess == false) {
                    LoginMessage.Content = loginResponse.Message;
                    LoginMessage.Foreground = Brushes.Red;
                }
                Thread.Sleep(1000);
                var currentUser = UserSession.CurrenUser;
                if (currentUser is not null && currentUser.Role == UserRole.Client)
                {
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.MainFrame.Navigate(new ShopManagerPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new RegisterPage());
        }
    }
}
