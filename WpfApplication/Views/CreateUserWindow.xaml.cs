using BusinessObjects.Request.User;
using Services;
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
using System.Windows.Shapes;

namespace WpfApplication.Views
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == EmailTextBox)
            {
                if (!IsValidEmail(EmailTextBox.Text))
                {
                    CreateMessage.Content = "Please enter a valid email address";
                    CreateUserButton.IsEnabled = false;
                }
                else {
                    CreateMessage.Content = string.Empty;
                }
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox.Password.Length < 6)
            {
                CreateMessage.Content = "Password must be at least 6 characters long.";
                CreateUserButton.IsEnabled = false;
            }
            else { 
                CreateMessage.Content = string.Empty;
            }
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PasswordTextBox.Password))
                {
                    MessageBox.Show("UserName, Email, and Password are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    "Are you sure you want to create this user?",
                    "Confirm Create User",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result != MessageBoxResult.Yes)
                {
                    return;
                }

                var newUser = new CreateUserRequest
                {
                    UserName = UserNameTextBox.Text,
                    FullName = FullNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Address = AddressTextBox.Text,
                    RegistrationDate = DateTime.Now,
                    Password = PasswordTextBox.Password
                };

                var createResponse = _userService.CreateStaff(newUser);
                if (createResponse.IsSuccess)
                {
                    CreateMessage.Content = "Create Staff Successfully.";
                    CreateMessage.Foreground = Brushes.Green;
                }
                else
                {
                    CreateMessage.Content = createResponse.Message;
                }

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }


        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
