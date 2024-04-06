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
    /// Interaction logic for ShoppingListBuilderPage.xaml
    /// </summary>
    public partial class ShoppingListBuilderPage : Page
    {
        public ShoppingListBuilderPage()
        {
            InitializeComponent();
        }

        private void RecipeBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RecipeBuilderPage());
        }
        
        private void ShoppingListEditorPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShoppingListEditorPage());
        }
        
        private void ManageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddAll_Button(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
