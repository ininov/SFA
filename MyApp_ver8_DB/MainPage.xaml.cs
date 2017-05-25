using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyApp_ver8_DB.Resources;


namespace MyApp_ver8_DB
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                if (!context.DatabaseExists())
                    context.CreateDatabase();
            }
            using (LoginInfoContext context2 = new LoginInfoContext (LoginInfoContext.DBConnectionString))
            {
                if (!context2.DatabaseExists())
                    context2.CreateDatabase();
            }
            this.BackKeyPress += MainPage_BackKeyPress;
        }

        void MainPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Terminate();
            }
            else if(result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btn_student_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Student.xaml", UriKind.Relative));
        }

        private void btn_teacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TeacherLogin.xaml", UriKind.Relative));
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        
    }
}