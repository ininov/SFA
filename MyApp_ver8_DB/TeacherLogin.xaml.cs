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
       public partial class TeacherLogin : PhoneApplicationPage
    {
        public TeacherLogin()
        {
            InitializeComponent();
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB_loginInput add2 = new DB_loginInput();
            add2.AddLoginUser("admin", "admin");
             
            
            CheckCredentials check = new CheckCredentials();
            

            if (!check.checkListUsername(txtBox_UserName.Text))
                {
                    MessageBox.Show("Invalid username!");
                }
                else if (!check.checkListPassword(txtBox_Password.Password))
                {
                    MessageBox.Show("Invalid password!");
                }
                else
                {
                    NavigationService.Navigate(new Uri("/UsersList.xaml", UriKind.Relative));
                }
            }
        }
    }