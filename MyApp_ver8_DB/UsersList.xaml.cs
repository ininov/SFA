using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MyApp_ver8_DB
{
    public partial class UsersList : PhoneApplicationPage
    {
        public UsersList()
        {
            InitializeComponent();
            FetchDBinfo fetch = new FetchDBinfo();
            allusers.ItemsSource = fetch.getUsers();
            this.BackKeyPress += UsersList_BackKeyPress;
        }

        void UsersList_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
                MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            
        }

        private void btn_Click (object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
               case "btn_DeleteSingleUser":
                    String id = btn.Tag.ToString();
                    DeleteUser delete = new DeleteUser();
                    delete.DeleteSingleUser(id);
                    FetchDBinfo fetch = new FetchDBinfo();
                    allusers.ItemsSource = fetch.getUsers();
                   break;
                case "btn_ApproveUser":
                    String approveid = btn.Tag.ToString();
                    ApproveUser approve = new ApproveUser();
                    String status = "Approved";
                    approve.UpdateStatus(Convert.ToInt32(approveid),status);
                //    NavigationService.Navigate(new Uri("/UsersList.xaml?id=" + approveid, UriKind.Relative));
                    fetch = new FetchDBinfo();
                    allusers.ItemsSource = fetch.getUsers();
                    break;
            }
        }

        void NavigationService_Navigating (object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?","", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    NavigationService.Navigate (new Uri("/Main page.xaml", UriKind.Relative));
                }
            }
        }

     /*   private void btn_ApproveUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String approveid = btn.Tag.ToString();
            ApproveUser approve = new ApproveUser();
            String status = "Approved";
            approve.UpdateStatus(Convert.ToInt32(approveid), status);
            NavigationService.Navigate(new Uri("/UsersList.xaml?id=" + approveid, UriKind.Relative));
        }*/

    }

}