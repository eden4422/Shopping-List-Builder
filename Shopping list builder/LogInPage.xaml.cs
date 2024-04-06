using Shopping_list_builder.Classes;
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

namespace Shopping_list_builder
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Password;
            bool userFound;

            if (username != null && password != null)
            {
                DatabaseManager databaseManager = new DatabaseManager();
                userFound = databaseManager.logInUser(username, password);

                if(userFound)
                {
                    NavigationService?.Navigate(new ShoppingListBuilderPage());
                }
                else
                {
                    
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Password;

           
            if(username != null && password != null)
            {
                DatabaseManager databaseManager = new DatabaseManager();
                databaseManager.signUpUser(username, password);
            }
            
        }
    }
}
