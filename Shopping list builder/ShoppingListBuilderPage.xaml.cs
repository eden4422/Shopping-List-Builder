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
        ObservableCollection<Grocery> groceries;


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

            // Initialize and set the data context of the ListView
            groceries = new ObservableCollection<Grocery>();
            groceries.Add(new Grocery(5, "Apples"));
            groceries.Add(new Grocery(3, "Bananas"));
            groceries.Add(new Grocery(2, "Cheddar Cheese"));

            ShoppingList.ItemsSource = groceries;
        }

        class Grocery
        {
            public Grocery(int Quantity, string GroceryName) 
            {
                this.Quantity = Quantity;
                this.GroceryName = GroceryName;
            }

            public int Quantity { get; set; }
            public string GroceryName { get; set; }
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
            string? selectedItem = ItemsInRecipeList.SelectedItem.ToString();

            // Handle button click event
            if (selectedItem != null)
            {
                bool flag = true;
                foreach (Grocery grocery in groceries)
                {
                    if (grocery.GroceryName == selectedItem)
                    {
                        grocery.Quantity += 1;
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    groceries.Add(new Grocery(1, selectedItem));
                }

                ShoppingList.ItemsSource = null;

                ShoppingList.ItemsSource = groceries;
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

                bool flag = true;
                foreach (Grocery grocery in groceries)
                {
                    if (grocery.GroceryName == item)
                    {
                        grocery.Quantity += 1;
                        flag = false ;
                        break;
                    }
                }

                if (flag)
                {
                    groceries.Add(new Grocery(1, item));
                }
            }

            ShoppingList.ItemsSource = null;

            ShoppingList.ItemsSource = groceries;
        }

        private bool searchTable(string groceryName)
        {
            foreach (Grocery grocery in ShoppingList.Items)
            {
                if (grocery.GroceryName == groceryName)
                {
                    grocery.Quantity += 1;
                    return true;
                }
            }

            return false;
        }

        // ShoppingList
        // ItemsInRecipeList
        // RecipeList
        
    }
}
