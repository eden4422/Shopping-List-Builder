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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Recipe> recipes = new List<Recipe>() {
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
            temp.addItem("flour", 210, "unit");
            //by stick
            temp.addItem("butter", 1, "unit");
            temp.addItem("granulated sugar", 150, "unit");
            temp.addItem("egg", 1, "unit");
            //Dont worry about little stuff
            temp.addItem("baking soda", -1, "unit");
            temp.addItem("cream of tartar", -1, "unit");
            temp.addItem("salt", -1, "unit");
            recipes[0] = temp;

            //Spaghetti https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782
            temp = recipes[1];
            temp.addItem("italian sausage", 907.19, "unit");
            temp.addItem("onion", 1, "unit");
            temp.addItem("garlic clove", 4, "unit");
            temp.addItem("can diced tomatoes", 1, "unit");
            temp.addItem("can tomato paste", 2, "unit");
            temp.addItem("can tomato sauce", 2, "unit");
            temp.addItem("basil", -1, "unit");
            temp.addItem("black pepper", -1, "unit");
            temp.addItem("red wine", 1, "unit");
            temp.addItem("spaghetti", 453.6, "unit");
            temp.addItem("parmesan", -1, "unit");
            recipes[1] = temp;

            //Mac and Cheese
            temp = recipes[2];
            temp.addItem("elbow pasta", 453.6, "unit");
            temp.addItem("butter", 1, "unit");
            temp.addItem("flour", 60, "unit");
            //gallons for liquids
            temp.addItem("whole milk", .1, "unit");
            temp.addItem("half and half", 1.6, "unit");
            temp.addItem("cheddar", 464, "unit");
            temp.addItem("gruyere", 226.8, "unit");
            temp.addItem("salt", -1, "unit");
            temp.addItem("black pepper", -1, "unit");
            temp.addItem("paprika", -1, "unit");

            Brain.RecipesDatabase = recipes;

            MainFrame.Navigate(new ShoppingListBuilderPage());
        }
    }
}
