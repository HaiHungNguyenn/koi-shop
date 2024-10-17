using BusinessObjects.Dto;
using Services;
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
using WpfApplication.Views.ManagerUserControl;

namespace WpfApplication.Views
{
    /// <summary>
    /// Interaction logic for ShopManagerPage.xaml
    /// </summary>
    public partial class ShopManagerPage : Page
    {
        private readonly IAuthService _authService = new AuthService();
        private readonly UserSession _currentUser; 
        public ShopManagerPage()
        {
            _currentUser = UserSession.CurrenUser;
            InitializeComponent();
            WelcomeLable.Content = $"Hello {_currentUser.Name}, welcome to management panel";
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is TabControl tabControl && tabControl.SelectedItem is TabItem selectedTab)
            {
                string pageName = selectedTab.Tag.ToString();

                switch (pageName)
                {
                    case "AccountsPage":
                        MainContentFrame.Navigate(new AccountManageControl());
                        break;
                    case "FishPage":
                        MainContentFrame.Navigate(new FishManageControl());
                        break;
                    case "FishPackagePage":
                        //MainContentFrame.Navigate(new FishPackagePage());
                        break;
                    case "UserProfilePage":
                        //MainContentFrame.Navigate(new UserProfilePage());
                        break;
                    case "PromotionPage":
                        break;
                    case "OrderPage":
                        break;
                    case "KoiCategoryPage";
                        break;
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var logoutresponse = _authService.Logout();
                if (logoutresponse.IsSuccess)
                {
                    MessageBox.Show($"Goodbye. See you next time", "Successfully Logout", MessageBoxButton.OK);
                    MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
                    mainWindow.MainFrame.Navigate(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
