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
    public partial class Status : PhoneApplicationPage
    {
        public Status()
        {
            InitializeComponent();
        }

        private void btn_checkStatus_Click(object sender, RoutedEventArgs e)
        {
            CheckStatus check = new CheckStatus();
            if (check.checkExistListFaknum(txtBox_facNum.Text))
            {
                if (check.checkListFaknum(txtBox_facNum.Text))
                {
                    MessageBox.Show("Congratulations! You have been APPROVED!");
                }
                else
                {
                    MessageBox.Show("Status is in 'Pending approval'!");
                }
            }
            else
            {
                MessageBox.Show("Student with this faculty number not found!");
            }

           
        }
    }
}