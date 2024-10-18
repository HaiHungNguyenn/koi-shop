using BusinessObjects;
using BusinessObjects.Dto;
using Microsoft.VisualBasic.ApplicationServices;
using Services;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication.Views.ManagerUserControl
{
    /// <summary>
    /// Interaction logic for AccountManageControl.xaml
    /// </summary>
    public partial class AccountManageControl : UserControl
    {
        //private List<UserDto> users;
        private readonly IUserService _userService = new UserService();
        public AccountManageControl()
        {
            InitializeComponent();
            LoadUserData();
        }
        private void LoadUserData()
        {
            try
            {
                var users = _userService.GetStaffs();
                userDataGrid.ItemsSource = users.Data as IEnumerable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK);
            }
        }
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BusinessObjects.User user)
            {
                MessageBox.Show($"Detail of {user.UserName}:\n\nFull Name: {user.FullName}\nEmail: {user.Email}\nPhone: {user.PhoneNumber}", "User Details");
            }
        }

        private void CreateStaffButton_Click(object sender, RoutedEventArgs e)
        {
            var createUserWindow = new CreateUserWindow();
            if (createUserWindow.ShowDialog() == true) {
                LoadUserData();
            }
        }
    }
}
