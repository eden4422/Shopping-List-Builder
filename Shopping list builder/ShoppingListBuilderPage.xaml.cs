using Shopping_list_builder.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
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
            temp.addItem("flour", 210);
            //by stick
            temp.addItem("butter", 1);
            temp.addItem("granulated sugar", 150);
            temp.addItem("egg", 1);
            //Dont worry about little stuff
            temp.addItem("baking soda", -1);
            temp.addItem("cream of tartar", -1);
            temp.addItem("salt", -1);
            recipes[0] = temp;

            //Spaghetti https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782
            temp = recipes[1];
            temp.addItem("italian sausage", 907.19);
            temp.addItem("onion", 1);
            temp.addItem("garlic clove", 4);
            temp.addItem("can diced tomatoes", 1);
            temp.addItem("can tomato paste", 2);
            temp.addItem("can tomato sauce", 2);
            temp.addItem("basil", -1);
            temp.addItem("black pepper", -1);
            temp.addItem("red wine", 1);
            temp.addItem("spaghetti", 453.6);
            temp.addItem("parmesan", - 1);
            recipes[1] = temp;

            //Mac and Cheese
            temp = recipes[2];
            temp.addItem("elbow pasta", 453.6);
            temp.addItem("butter", 1);
            temp.addItem("flour", 60);
            //gallons for liquids
            temp.addItem("whole milk", .1);
            temp.addItem("half and half", 1.6);
            temp.addItem("cheddar", 464);
            temp.addItem("gruyere", 226.8);
            temp.addItem("salt", - 1);
            temp.addItem("black pepper", -1);
            temp.addItem("paprika", -1);


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

        private void RecipesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArrayList itemsToDisplay = new ArrayList();

            int selected = RecipesList.SelectedIndex;
            foreach (Item i in recipes[selected].Items)
            {
                String temp;
                temp = "";
                temp = i.ID;
                if (i.Amount != -1)
                {
                    temp = temp + " " + i.Amount;
                }
                itemsToDisplay.Add(temp);
            }
            ItemsInRecipeList.ItemsSource = itemsToDisplay;
            //Keep these for later. Can populate with just the objects. Cant figure out how to display amounts from here though :/
            //But useful to reference.
            //ItemsInRecipeList.DisplayMemberPath = "ID";
            //ItemsInRecipeList.ValueMember = "Amount";
            //ItemsInRecipeList.ItemsSource = recipes[selected].Items;
        }

        // ShoppingList
        // ItemsInRecipeList
        // RecipeList

    }
}
