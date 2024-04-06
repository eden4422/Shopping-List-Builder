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
    /// Interaction logic for ShoppingListBuilderPage.xaml
    /// </summary>
    public partial class ShoppingListBuilderPage : Page
    {

        List<Recipe> recipes;

        public ShoppingListBuilderPage()
        {
            InitializeComponent();


            recipes = new List<Recipe>() {
                new Recipe("Cookies", "Yummy cookies."),
                new Recipe("Spaghetti", "Mom's old fashioned spaghetti."),
                new Recipe("Mac and Cheese", "Cheesiest macaroni in the world."),
                new Recipe("Boglogna Sandwich", "Plain, but delicious."),
                new Recipe("Kung Pao Chicken", "American Chinese Cuisine at its finest."),
                new Recipe("Pork Fried Rice", "A staple.") 
            };

            foreach (Recipe recipe in recipes)
            {
                RecipesList.Items.Add(recipe.Name);
            }
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
            // Pops up a modal window that does something.
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            // select an item in ItemsInRecipe, add that item to Shopping List

            ItemsInRecipeList.Items.Add("Ingredient");
        }

        private void AddAll_Button(object sender, RoutedEventArgs e)
        {
            // Adds all of the items in Items in Recipe to Shopping List
        }

        // ShoppingList
        // ItemsInRecipeList
        // RecipeList
        
    }
}
