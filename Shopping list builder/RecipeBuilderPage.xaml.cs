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
    /// Interaction logic for RecipeBuildPage.xaml
    /// </summary>
    public partial class RecipeBuilderPage : Page
    {

        public Item SelectedItem;

        public Recipe SelectedRecipe;

        public List<Item> WindowedItems = new List<Item>();

        public List<Recipe> WindowedRecipes = new List<Recipe>();

        public RecipeBuilderPage()
        {
            InitializeComponent();
        }

        private void IncrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            Window1 popUp = new Window1();
            popUp.Show();
        }

        private void DecrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            Window1 popUp = new Window1();
            popUp.Show();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Window1 inputDialog = new Window1();

            if (inputDialog.ShowDialog() == true)
            {
                string inputstring = inputDialog.name;
                Item newItem = new Item(inputstring, 0.0);
                this.WindowedItems.Add(newItem);
            }

            UpdateIngredientList();
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {

            foreach (Item item in SelectedRecipe.Items)
            {
                string itemName = item.ID;
                double itemAmmount = item.Amount;

                IngredientsListView.Items.Add(itemName + itemAmmount);
            }
        }

        private void UpdateIngredientList()
        {
            foreach (Item item in WindowedItems)
            {
                IngredientsListView.Items.Add(item.ID + item.Amount);
            }
        }

        private void UpdateRecipeList()
        {
            foreach (Recipe recipe in WindowedRecipes)
            {
                RecipesListView.Items.Add(recipe.Name);
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {

            Window1 inputDialog = new Window1();
            //inputDialog.Show();
            if (inputDialog.ShowDialog() == true)
            {
                string inputstring = inputDialog.name;
                Recipe newItem = new Recipe(inputstring, "");
                this.WindowedRecipes.Add(newItem);
            }

            UpdateRecipeList();
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            int deleteIndex = this.IngredientsListView.SelectedIndex;

            this.WindowedItems.RemoveAt(deleteIndex);

            this.UpdateRecipeList();

            WindowedItems.Clear();
            UpdateIngredientList();

            if (RecipesListView.Items.Count > 0)
            {
                RecipesListView.SelectedIndex = 0;
                this.SelectedRecipe = WindowedRecipes[0];
            }
        }
        
        private void ShoppingListBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShoppingListBuilderPage());
        }

        private void RecipesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = RecipesListView.SelectedIndex;
            SelectedRecipe = WindowedRecipes[index];

        }

        private void IngredientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = IngredientsListView.SelectedIndex;
            SelectedItem = WindowedItems[index];
        }
    }
}

