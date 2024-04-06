using Shopping_list_builder.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
                //new Recipe("Boglogna Sandwich", "Plain, but delicious."),
                //new Recipe("Kung Pao Chicken", "American Chinese Cuisine at its finest."),
                //new Recipe("Pork Fried Rice", "A staple.") 
            };

            //Adding those recipe ingredients
            Recipe temp;

            //Cookies https://www.sweetestmenu.com/chewy-snickerdoodle-cinnamon-cookies/
            temp = recipes[0];
            //using grams for weight
            temp.addItem("flour", 210, "g");
            //by stick
            temp.addItem("butter", 1, "item");
            temp.addItem("granulated sugar", 150, "g");
            temp.addItem("egg", 1, "item");
            //Dont worry about little stuff
            temp.addItem("baking soda", -1, "");
            temp.addItem("cream of tartar", -1, "");
            temp.addItem("salt", -1, "");
            recipes[0] = temp;

            //Spaghetti https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782
            temp = recipes[1];
            temp.addItem("italian sausage", 907.19, "g");
            temp.addItem("onion", 1, "item");
            temp.addItem("garlic clove", 4, "item");
            temp.addItem("can diced tomatoes", 1, "item");
            temp.addItem("can tomato paste", 2, "item");
            temp.addItem("can tomato sauce", 2, "item");
            temp.addItem("basil", -1, "");
            temp.addItem("black pepper", -1, "");
            temp.addItem("red wine", 1, "item");
            temp.addItem("spaghetti", 453.6, "g");
            temp.addItem("parmesan", -1, "");
            recipes[1] = temp;

            //Mac and Cheese
            temp = recipes[2];
            temp.addItem("elbow pasta", 453.6, "g");
            temp.addItem("butter", 1, "item");
            temp.addItem("flour", 60, "g");
            //gallons for liquids
            temp.addItem("whole milk", .1, "gal");
            temp.addItem("half and half", 1.6, "gal");
            temp.addItem("cheddar", 464, "g");
            temp.addItem("gruyere", 226.8, "g");
            temp.addItem("salt", -1, "");
            temp.addItem("black pepper", -1, "");
            temp.addItem("paprika", -1, "");


            foreach (Recipe recipe in recipes)
            {
                RecipesList.Items.Add(recipe.Name);
            }

            // Create a list to store grocery items
            List<string> groceryList = new List<string>();

            foreach (var item in groceryList)
            {
                ItemsInRecipeList.Items.Add(item);
            }

            shoppingList = new ShoppingList();
            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        public ShoppingListBuilderPage(ShoppingList s)
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

            //Adding those recipe ingredients
            Recipe temp;

            //Cookies https://www.sweetestmenu.com/chewy-snickerdoodle-cinnamon-cookies/
            temp = recipes[0];
            //using grams for weight
            temp.addItem("flour", 210, "g");
            //by stick
            temp.addItem("butter", 1, "item");
            temp.addItem("granulated sugar", 150, "g");
            temp.addItem("egg", 1, "item");
            //Dont worry about little stuff
            temp.addItem("baking soda", -1, "");
            temp.addItem("cream of tartar", -1, "");
            temp.addItem("salt", -1, "");
            recipes[0] = temp;

            //Spaghetti https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782
            temp = recipes[1];
            temp.addItem("italian sausage", 907.19, "g");
            temp.addItem("onion", 1, "item");
            temp.addItem("garlic clove", 4, "item");
            temp.addItem("can diced tomatoes", 1, "item");
            temp.addItem("can tomato paste", 2, "item");
            temp.addItem("can tomato sauce", 2, "item");
            temp.addItem("basil", -1, "");
            temp.addItem("black pepper", -1, "");
            temp.addItem("red wine", 1, "item");
            temp.addItem("spaghetti", 453.6, "g");
            temp.addItem("parmesan", -1, "");
            recipes[1] = temp;

            //Mac and Cheese
            temp = recipes[2];
            temp.addItem("elbow pasta", 453.6, "g");
            temp.addItem("butter", 1, "item");
            temp.addItem("flour", 60, "g");
            //gallons for liquids
            temp.addItem("whole milk", .1, "gal");
            temp.addItem("half and half", 1.6, "gal");
            temp.addItem("cheddar", 464, "g");
            temp.addItem("gruyere", 226.8, "g");
            temp.addItem("salt", -1, "");
            temp.addItem("black pepper", -1, "");
            temp.addItem("paprika", -1, "");


            foreach (Recipe recipe in recipes)
            {
                RecipesList.Items.Add(recipe.Name);
            }

            this.shoppingList = s;
            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        private void RecipeBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RecipeBuilderPage());
        }
        
        private void ShoppingListEditorPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShoppingListEditorPage(shoppingList));
        }
        
        private void ManageButton_Click(object sender, RoutedEventArgs e)
        {
            // Pops up a modal window that does something.
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {

            Item? selectedItem = (Item)ItemsInRecipeList.SelectedItem;

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
            foreach (Item item in ItemsInRecipeList.Items)
            {
                shoppingList.addItem(item);
            }

            ShoppingList.ItemsSource = null;

            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        private void RecipesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = RecipesList.SelectedIndex;
            // ArrayList itemsToDisplay = new ArrayList();
            ObservableCollection<Item> itemsToDisplay = new ObservableCollection<Item>();

            ItemsInRecipeList.ItemsSource = recipes[selected].Items;

            /*
            foreach (Item i in recipes[selected].Items)
            {
                String temp = i.ID + " ";
                if (i.Amount > 0)
                {
                    temp = temp + i.Amount;
                }
                itemsToDisplay.Add(temp);
            }
             */
            //test comment. Ignore
        }
    }
}
