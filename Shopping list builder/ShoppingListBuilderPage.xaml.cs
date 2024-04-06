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

            Brain.LoadRecipesJSON();

            recipes = Brain.RecipesDatabase;


            

            //Cookies https://www.sweetestmenu.com/chewy-snickerdoodle-cinnamon-cookies/
            
            //Spaghetti https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782
            
            

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



            this.recipes = Brain.RecipesDatabase;

            foreach (Recipe recipe in recipes)
            {
                RecipesList.Items.Add(recipe.Name);
            }

            this.shoppingList = s;
            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        private void RecipeBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            Brain.RecipesDatabase = this.recipes;
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


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.recipes = Brain.RecipesDatabase;
        }


    }
}
