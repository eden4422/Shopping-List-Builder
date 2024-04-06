using Shopping_list_builder.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        ShoppingList shoppingList;


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

            // Create a list to store grocery items
            List<string> groceryList = new List<string>();

            // Add grocery items to the list
            groceryList.Add("Apples");
            groceryList.Add("Bananas");
            groceryList.Add("Milk");
            groceryList.Add("Bread");
            groceryList.Add("Eggs");
            groceryList.Add("Cheese");
            groceryList.Add("Chicken");

            foreach (var item in groceryList)
            {
                ItemsInRecipeList.Items.Add(item);
            }





            shoppingList = new ShoppingList();

            ShoppingList.ItemsSource = shoppingList.groceries;
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

            string? selectedItem = ItemsInRecipeList.SelectedItem?.ToString();

            // Handle button click event
            if (selectedItem != null)
            {
                shoppingList.addItem(selectedItem);

                ShoppingList.ItemsSource = null;

                ShoppingList.ItemsSource = shoppingList.groceries;
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
        }

        private void AddAll_Button(object sender, RoutedEventArgs e)
        {
            foreach (string item in ItemsInRecipeList.Items)
            {
                shoppingList.addItem(item);
            }

            ShoppingList.ItemsSource = null;

            ShoppingList.ItemsSource = shoppingList.groceries;
        }
        
    }
}
