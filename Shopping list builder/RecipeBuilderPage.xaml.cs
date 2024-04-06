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
    /// Interaction logic for RecipeBuildPage.xaml
    /// </summary>
    public partial class RecipeBuilderPage : Page
    {
        public RecipeBuilderPage()
        {
            InitializeComponent();
        }

        private void IncrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DecrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void ShoppingListBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShoppingListBuilderPage());
        }
    }
}
