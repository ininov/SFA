using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;

namespace MyApp_ver8_DB
{
    public partial class FillForm : PhoneApplicationPage
    {
        private bool stats;
        public FillForm()
        {
            InitializeComponent();
        }

        public void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            String enteredname = txtBox_name.Text;
            String enteredFacNum = txtBox_facNum.Text;          
            String enteredgender = null;
            if(radio_female.IsChecked == true)
            {
                enteredgender = radio_female.Content.ToString();
            }
            else if (radio_male.IsChecked == true)
            {
                enteredgender = radio_male.Content.ToString();
            }
            
            String enteredgrade = txtBox_grade.Text;
            
            //Faculty
            String enteredfaculty = null;
            if (radio_Fac_FKSU.IsChecked == true)
            {
                enteredfaculty = radio_Fac_FKSU.Content.ToString();
            }
            else if (radio_Fak_TELE.IsChecked == true)
            {
                enteredfaculty = radio_Fak_TELE.Content.ToString();
            }

            //specialty sem7
            String enteredsemester7 = null;

            if (radio_Sem7_1.IsChecked == true)
            {
                enteredsemester7 = radio_Sem7_1.Content.ToString();
            }
            else if (radio_Sem7_2.IsChecked == true)
            {
                enteredsemester7 = radio_Sem7_2.Content.ToString();
            }
            else if (radio_Sem7_3.IsChecked == true)
            {
                enteredsemester7 = radio_Sem7_3.Content.ToString();
            }

            //specialty sem8
            String enteredsemester8 = null;
            if (radio_Sem8_1.IsChecked == true)
            {
                enteredsemester8 = radio_Sem8_1.Content.ToString();
            }
            else if (radio_Sem8_2.IsChecked == true)
            {
                enteredsemester8 = radio_Sem8_2.Content.ToString();
            }
            else if (radio_Sem8_3.IsChecked == true)
            {
                enteredsemester8 = radio_Sem8_3.Content.ToString();
            }

            String enteredstatus = "Not approved";

            Validations();
            
            if (stats)
            {
                DB_input add = new DB_input();
                if (!String.IsNullOrEmpty(enteredname) &&
                    !String.IsNullOrEmpty(enteredgender) &&
                    !String.IsNullOrEmpty(enteredFacNum) &&
                    !String.IsNullOrEmpty(enteredgrade) &&
                    !String.IsNullOrEmpty(enteredfaculty) &&
                    !String.IsNullOrEmpty(enteredsemester7) &&
                    !String.IsNullOrEmpty(enteredsemester8))
                {
                    add.AddUser(enteredname, enteredFacNum, enteredgrade,
                        enteredgender, enteredfaculty,
                        enteredsemester7, enteredsemester8, enteredstatus);
                }
                {

                    MessageBoxResult result = MessageBox.Show("Do you wish to continue?", "Almost done", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        MessageBox.Show("Form submited successfully!");
                        NavigationService.Navigate(new Uri("/Student.xaml", UriKind.Relative));
                        
                    }
                    
                    
                }
            }
                
        }

       private void Radio_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;

            switch (rdo.Name)
            {
                case "radio_Fac_FKSU":  
                     Semester7.Visibility = Visibility.Visible;
                         radio_Sem7_1.Content = "КИ";
                         radio_Sem7_2.Content = "СС";
                         radio_Sem7_3.Content = "ПРС";
                     Semester8.Visibility = Visibility.Visible;
                         radio_Sem8_1.Content = "ПТСК";
                         radio_Sem8_2.Content = "Пр. на C#";
                         radio_Sem8_3.Content = "ПВС";
            break;
                case "radio_Fak_TELE":
                     Semester7.Visibility = Visibility.Visible;
                         radio_Sem7_1.Content = "АС";
                         radio_Sem7_2.Content = "ТС";
                         radio_Sem7_3.Content = "КПК";
                     Semester8.Visibility = Visibility.Visible;
                         radio_Sem8_1.Content = "ЦТ";
                         radio_Sem8_2.Content = "ММ";
                         radio_Sem8_3.Content = "РМ";
            break;
            }
       }

        public void Validations ()
        {
            CheckStatus existFacnum = new CheckStatus();
            stats = false;
            if (!Regex.IsMatch(txtBox_name.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))
            {
                MessageBox.Show("Invalid UserName");

            }
            else if (txtBox_facNum.Text.Length < 9 || txtBox_facNum.Text.Length > 9)
            {
                MessageBox.Show("Faculty number should be 9 numbers!");
            }
            else if (existFacnum.checkExistListFaknum(txtBox_facNum.Text))
            {
                MessageBox.Show("User with entered faculty number already exists!");
            }
            else if (!Regex.IsMatch(txtBox_grade.Text.Trim(), @"[0-9]$"))
            {
                MessageBox.Show("Grade is not valid!");
            }
            else if (radio_female.IsChecked == false && radio_male.IsChecked == false)
            {
                MessageBox.Show("Please select faculty!");
            }
            else if (radio_Fac_FKSU.IsChecked == false && radio_Fak_TELE.IsChecked == false)
            {
                MessageBox.Show("Please select a gender!");
            }
            else if (radio_Sem7_1.IsChecked == false && radio_Sem7_2.IsChecked == false && radio_Sem7_3.IsChecked == false)
            {
                MessageBox.Show("Please select desired specialty for Semester 7");
            }
            else if (radio_Sem8_1.IsChecked == false && radio_Sem8_2.IsChecked == false && radio_Sem8_3.IsChecked == false)
            {
                MessageBox.Show("Please select desired specialty for Semester 8!");
            }
            else
            {
               stats = true;
            }
        }
    }



   
}