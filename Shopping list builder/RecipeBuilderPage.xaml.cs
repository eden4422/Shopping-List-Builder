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
            this.WindowedRecipes = Brain.RecipesDatabase;

            UpdateRecipeList();


        }

        private void IncrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem.amount++;
            }
            UpdateIngredientList();
        }

        private void DecrementIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem.amount--;
            }
            UpdateIngredientList();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Window2 inputDialog = new Window2();

            if (inputDialog.ShowDialog() == true)
            {
                string inputstring = inputDialog.name;
                string inputunit = inputDialog.unit;

                Item newItem = new Item(inputstring, 0.0, inputunit);
                this.SelectedRecipe.Items.Add(newItem);
            }

            UpdateIngredientList();
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            int deleteIndex = IngredientsListView.SelectedIndex;

            this.SelectedRecipe.Items.RemoveAt(deleteIndex);

            this.UpdateIngredientList();
        }

        private void UpdateIngredientList()
        {
            IngredientsListView.Items.Clear();

            foreach (Item item in SelectedRecipe.Items)
            {
                IngredientsListView.Items.Add(item.ID + " | " + item.Amount + " | "+ item.unit);
            }
        }

        private void UpdateRecipeList()
        {
            RecipesListView.Items.Clear();

            foreach (Recipe recipe in WindowedRecipes)
            {
                RecipesListView.Items.Add(recipe.Name);
            }

            RecipesListView.SelectedIndex = RecipesListView.Items.Count - 1;
            if (RecipesListView.Items.Count > 0)
            {
                SelectedRecipe = WindowedRecipes[0];
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {

            Window1 inputDialog = new Window1();

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
            int deleteIndex = RecipesListView.SelectedIndex;

            this.WindowedRecipes.RemoveAt(deleteIndex);
            RecipesListView.Items.RemoveAt(deleteIndex);


            this.UpdateRecipeList();

            this.UpdateIngredientList();



        }
        
        private void ShoppingListBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            Brain.RecipesDatabase = this.WindowedRecipes;
            Brain.SaveRecipesJSON();

            NavigationService?.Navigate(new ShoppingListBuilderPage());

            
        }

        private void RecipesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int index = RecipesListView.SelectedIndex;
            if (index != -1) { SelectedRecipe = WindowedRecipes[index]; }

            UpdateIngredientList();
        }

        private void IngredientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = IngredientsListView.SelectedIndex;
            if (index != -1)
            {
                SelectedItem = SelectedRecipe.Items[index];
            }
        }
    }
}

